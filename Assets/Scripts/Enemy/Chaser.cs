using UnityEngine;
using System.Collections;

public class Chaser : Enemy {

	Animator animator;
	float playerCheckRadius;
	Collider2D playerDetected;
	Vector2 moveDirection;
	public LayerMask whatIsPlayer;

	// Use this for initialization
	void Start () {
		maxHealth = 15;
		health = maxHealth;
		maxSpeed = 10f;
		playerCheckRadius = maxSpeed;
		animator = GetComponent<Animator>();
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			dealDamage(other.gameObject, 7, true, 15);
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			KnockBack(new Vector2(Mathf.Cos(angle) * 30f, Mathf.Sin(angle) * 30f));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(rigidbody2D.velocity.x != 0f || rigidbody2D.velocity.y != 0f){
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * (180f / Mathf.PI) - 90f);
			if(transform.eulerAngles.z < 360f)
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360f);
		}

		if(!canMove && stunnedCD < Time.time)
			canMove = true;
		
		if(canMove){
			playerDetected = Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);

			if(playerDetected){
				float angle = Mathf.Atan2(transform.position.y - playerDetected.transform.position.y, transform.position.x - playerDetected.transform.position.x);
				rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ((-0.6f) * (maxSpeed + 1f - Vector2.Distance(transform.position, playerDetected.transform.position))) * slow;
			}
		}

		if(slowDuration < Time.time)
			slow = 1f;
		if(immunityCD > Time.time)
			animator.SetBool("isDamaged", true);
		else
			animator.SetBool("isDamaged", false);
	}
}
