//<Summary>
//This is a class for the Chaser enemy. The chaser will (as the name implies) chase the player down when the player is within
//its area of influence. The chaser will start chasing slowly when the player is far away, then faster and faster as the player
//gets closer. The class extends from the Enemy class.
//</Summary>

using UnityEngine;
using System.Collections;

public class Chaser : Enemy {			//Extends from the Enemy class.

	//Creating variables
	Animator animator;					
	float playerCheckRadius;
	Collider2D playerDetected;
	Vector2 moveDirection;
	public LayerMask whatIsPlayer;

	// Use this for initialization
	void Start () {
		maxHealth = 15;			//Assigning some health and max speed to the Chaser, and finding the animator.
		health = maxHealth;
		maxSpeed = 10f;
		playerCheckRadius = maxSpeed;//Also sets the radius for checking for the player.
		animator = GetComponent<Animator>();
	}

	protected override void OnCollisionEnter2D(Collision2D other){					//Called when the chaser collides with something.
		if(other.gameObject.tag == "Player"){										//If it collides with a player, deal damage to
			dealDamage(other.gameObject, 7, true, 15);								//the player and knock the player back, 
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			KnockBack(new Vector2(Mathf.Cos(angle) * 15f, Mathf.Sin(angle) * 15f));	//then knock itself away from the player.
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(rigidbody2D.velocity.x != 0f || rigidbody2D.velocity.y != 0f){			//If the Chaser is moving, rotate it so its front is facing the way it is moving.
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * (180f / Mathf.PI) - 90f);
			if(transform.eulerAngles.z < 360f)
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360f);
		}

		if(!canMove && stunnedCD < Time.time)			//If the Chaser is unable to move, but it should be allowed to,	
			canMove = true;								//set canMove to true to allow it to move again.
		
		if(canMove){																						//If the Chaser is able to move,
			playerDetected = Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);	//try to find a player based on the playerCheckVariable, in the "whatIsPlayer"
			rigidbody2D.velocity = Vector2.zero;															//layer, and set the Chasers velocity to 0 (so the chaser will stand still as
																											//a standard).
			if(playerDetected){																				//If a player has been detected, chase the player based on position.
				float angle = Mathf.Atan2(transform.position.y - playerDetected.transform.position.y, transform.position.x - playerDetected.transform.position.x);
				rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * ((-0.6f) * (maxSpeed + 1f - Vector2.Distance(transform.position, playerDetected.transform.position))) * slow;
			}
		}

		if(slowDuration < Time.time)				//If the chaser shouldn't be slowed,
			slow = 1f;								//stop slowing it.
		if(immunityCD > Time.time)					//If the chaser has recently sustained damage, and is now immune,
			animator.SetBool("isDamaged", true);	//animate it taking damage,
		else 										//otherwise don't animate it.
			animator.SetBool("isDamaged", false);
	}
}
