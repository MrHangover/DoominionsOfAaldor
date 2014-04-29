using UnityEngine;
using System.Collections;

public class AISlinger : Enemy{
	
	Vector2 moveDirection;
	Collider2D playerDetected;
	bool canFire = true;
	float fireTimer = 0f;
	float playerCheckRadius = 7f;
	float moveTimer = 0f;
	Animator animator;
	public Rigidbody2D projectile;
	public LayerMask whatIsPlayer;
	public Transform playerCheck;
	public float maxMoveWait = 1.5f;
	public float minMoveWait = 0.6f;

	// Use this for initialization
	void Start () {
		moveDirection.x = 0f;
		moveDirection.y = 0f;
		maxSpeed = 10;
		maxHealth = 10;
		health = maxHealth;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(!canMove && stunnedCD < Time.time)
			canMove = true;

		if(canMove){
			playerDetected = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
			rigidbody2D.velocity = moveDirection * slow;

			if(playerDetected){
				if(fireTimer < 0.4f){
					moveTimer = 0.19f;
					animator.SetBool("isShooting", true);
				}
				if(canFire){
					Fire(playerDetected.transform.position);
					canFire = false;
					fireTimer = 3f;
					animator.SetBool("isShooting", false);
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

		if(slowDuration < Time.time)
			slow = 1f;
		if(immunityCD > Time.time)
			animator.SetBool("isDamaged", true);
		else
			animator.SetBool("isDamaged", false);
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		moveDirection = -moveDirection;
		if(other.gameObject.tag == "Player"){
			dealDamage(other.gameObject, 5, true, 50);
		}
	}

	void Fire(Vector2 playerPos){
		Rigidbody2D clone;
		float angle = Mathf.Atan2(playerCheck.position.y - playerPos.y, playerCheck.position.x - playerPos.x);
		clone = Instantiate(projectile, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * -0.9f, transform.rotation) as Rigidbody2D;
		clone.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * -20f;
	}

	Vector2 NextMove(){
		int r = Random.Range (1, 5);
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
