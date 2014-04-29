//<Summary>
//This is the class for the Archer enemy. When the archer detects a player in it's area of influence,
//it will try to get closer to the player is far away, and if the player is close, it will try to run
//away from the player. It will shoot at the player if it isn't running away from it or running towards the player.
//It extends from the Enemy class.
//</Summary>

using UnityEngine;
using System.Collections;

public class Archer : Enemy {

	//Creating variables for later use.
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
		maxHealth = 8;							//Setting the Archers speed, health and are of influence.
		health = maxHealth;
		maxSpeed = 3f;
		playerCheckRadius = 15f;
		animator = GetComponent<Animator>();
	}

	protected override void OnCollisionEnter2D(Collision2D other){		//Called whenever the Archer collides with something.
		if(other.gameObject.tag == "Player"){							//If it collides with the player,
			dealDamage(other.gameObject, 1, false);						//deal 1 damage to the player, and knock itself away from the player.
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			KnockBack(new Vector2(Mathf.Cos(angle) * 12f, Mathf.Sin(angle) * 12f));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		animator.SetBool("isWalking", false);	//As a standard, the Archer isn't animating its walking animation.
		
		if(!canMove && stunnedCD < Time.time)	//It the archer should be able to move, but isn't able to,
			canMove = true;						//allow it to move.
		
		if(canMove){							//If the archer can move, check for players withing its area of influence.
			playerDetected = Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);
			rigidbody2D.velocity = Vector2.zero;//Set its velocity to 0 as a standard.

			if(playerDetected){					//If a player has been detected withing the Arhcers area of influence, calculate the angle between it and the player,
				float angle = Mathf.Atan2(transform.position.y - playerDetected.transform.position.y, transform.position.x - playerDetected.transform.position.x);
				float distance = Vector2.Distance(transform.position, playerDetected.transform.position);		//and find the distance between it and the player.

				transform.eulerAngles = new Vector3(0f, 0f, angle * (180f / Mathf.PI) + 90f);					//Rotate the Archer so it is looking towards the player.
				if(angle * (180f / Mathf.PI) > 360f)
					transform.eulerAngles = new Vector3(0f, 0f, angle * (180f / Mathf.PI) - 360f);

				if(distance > 10f){																				//If the player is far away,
					rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * -maxSpeed * slow;	//move closer to the player,
					animator.SetBool("isWalking", true);
				}
				else if(distance < 7f){																			//If the player is close to the Archer,
					rigidbody2D.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * maxSpeed * slow;	//move away from the player.
					animator.SetBool("isWalking", true);
				}
				else{
					if(canShoot){																				//Otherwise, if the Archer is allowed to shoot,
						Fire (playerDetected.transform.position);												//shoot at the player,
						shootCD = Time.time + 3f;																//then wait 3 seconds before being allowed to shoot again.
						canShoot = false;
					}
				}
			}
		}

		if(!canShoot && shootCD < Time.time)		//If the Archer can't shoot but should be able to,
			canShoot = true;						//allow it to shoot.
		if(slowDuration < Time.time)				//If the Archer shouldn't be slowed,
			slow = 1f;								//cancel any slows.
		if(immunityCD > Time.time)					//If the Archer has recently sustained damage, and is now immune,
			animator.SetBool("isDamaged", true);	//animate it taking damage,
		else 										//otherwise, don't.
			animator.SetBool("isDamaged", false);
	}

	void Fire(Vector2 playerPos){																			//Function for shooting at the player.
		Rigidbody2D clone;																					//Create a projectile flying in the players direction, based on the players
		float angle = Mathf.Atan2(transform.position.y - playerPos.y, transform.position.x - playerPos.x);	//and the archers position.
		clone = Instantiate(projectile, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * -0.9f, transform.rotation) as Rigidbody2D;
		clone.AddForce(new Vector2(Mathf.Cos(angle) * -400f, Mathf.Sin(angle) * -400f));
	}
}
