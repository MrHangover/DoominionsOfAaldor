using UnityEngine;
using System.Collections;

public class Archer : Enemy {

	Animator animator;
	float playerCheckRadius;
	Collider2D playerDetected;
	Vector2 moveDirection;
	bool canShoot = true;
	float shootCD = 0f;
	public LayerMask whatIsPlayer;
	public Rigidbody2D projectile;

	// Use this for initialization
	void Start () {
		maxHealth = 8;
		health = maxHealth;
		maxSpeed = 3f;
		playerCheckRadius = 15f;
		animator = GetComponent<Animator>();
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			dealDamage(other.gameObject, 1, false);
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			KnockBack(new Vector2(Mathf.Cos(angle) * 12f, Mathf.Sin(angle) * 12f));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		animator.SetBool("isWalking", false);

		/*if(rigidbody2D.velocity.x != 0f || rigidbody2D.velocity.y != 0f){
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * (180f / Mathf.PI) - 90f);
			if(transform.eulerAngles.z < 360f)
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360f);
		}*/
		
		if(!canMove && stunnedCD < Time.time)
			canMove = true;
		
		if(canMove){
			playerDetected = Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);
			rigidbody2D.velocity = Vector2.zero;

			if(playerDetected){
				float angle = Mathf.Atan2(transform.position.y - playerDetected.transform.position.y, transform.position.x - playerDetected.transform.position.x);
				float distance = Vector2.Distance(transform.position, playerDetected.transform.position);

				transform.eulerAngles = new Vector3(0f, 0f, angle * (180f / Mathf.PI) + 90f);
				if(angle * (180f / Mathf.PI) > 360f)
					transform.eulerAngles = new Vector3(0f, 0f, angle * (180f / Mathf.PI) - 360f);

				if(distance > 10f){
					rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * -maxSpeed * slow;
					animator.SetBool("isWalking", true);
				}
				else if(distance < 7f){
					rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * maxSpeed * slow;
					animator.SetBool("isWalking", true);
				}
				else{
					if(canShoot){
						Fire (playerDetected.transform.position);
						shootCD = Time.time + 3f;
						canShoot = false;
					}
				}
			}
		}

		if(!canShoot && shootCD < Time.time)
			canShoot = true;
		if(slowDuration < Time.time)
			slow = 1f;
		if(immunityCD > Time.time)
			animator.SetBool("isDamaged", true);
		else
			animator.SetBool("isDamaged", false);
	}

	void Fire(Vector2 playerPos){
		Rigidbody2D clone;
		float angle = Mathf.Atan2(transform.position.y - playerPos.y, transform.position.x - playerPos.x);
		clone = Instantiate(projectile, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * -0.9f, transform.rotation) as Rigidbody2D;
		clone.AddForce(new Vector2(Mathf.Cos(angle) * -400f, Mathf.Sin(angle) * -400f));
	}
}
