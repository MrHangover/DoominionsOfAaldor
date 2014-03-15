using UnityEngine;
using System.Collections;

public class AISlinger : MonoBehaviour {

	public Transform playerCheck;
	bool playerDetected = false;
	bool canFire = true;
	float fireTimer = 0.0f;
	float playerCheckRadius = 7f;
	public LayerMask whatIsPlayer;
	Vector2 moveDirection;
	float moveTimer = 0.0f;
	public float maxSpeed = 10f;

	public float maxMoveWait = 1.5f;
	public float minMoveWait = 0.6f;

	// Use this for initialization
	void Start () {
		moveDirection.x = 0f;
		moveDirection.y = 0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		playerDetected = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);

		rigidbody2D.velocity = moveDirection;

		if(playerDetected){
			if(fireTimer < 0.4f)
				moveTimer = 0.19f;
			if(canFire){
				Fire ();
				canFire = false;
				fireTimer = 3f;
			}
		}
		if(fireTimer < 0f){
			fireTimer = 0f;
			canFire = true;
		}
		if (moveTimer < 0f){
			moveDirection = NextMove();
			moveTimer = Random.Range (minMoveWait, maxMoveWait);
		}
		if(moveTimer < 0.2f)
			moveDirection = new Vector2(0, 0);

		fireTimer -= Time.deltaTime;
		moveTimer -= Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D other){
		moveDirection = -moveDirection;
	}

	void Fire(){
		Debug.Log("FIRE");
	}

	Vector2 NextMove(){
		int r = Random.Range (0, 5);
		switch(r){
		case 1:
			return new Vector2(1 * maxSpeed, 0);
		case 2:
			return new Vector2(0, 1 * maxSpeed);
		case 3:
			return new Vector2(-1 * maxSpeed, 0);
		case 4:
			return new Vector2(0, -1 * maxSpeed);
		default:
			return new Vector2(0, 0);
		}
	}
}
