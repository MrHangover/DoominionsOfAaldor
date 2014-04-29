//<Summary>
//This is class for controlling the Slinger enemy.
//The Slinger moves around in a random fashion, either north, south, east or west.
//If it detects a player close to it, it will stop for a short moment and shoot at the player.
//The class extends from the Enemy class.
//</Summary>

using UnityEngine;
using System.Collections;

public class AISlinger : Enemy{			//Extends from Enemy class.

	//Creating variables for later use.
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
		maxSpeed = 10;			//Setting the max speed
		maxHealth = 10;			//and the max health.
		health = maxHealth;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(!canMove && stunnedCD < Time.time)	//If the Slinger is unable to move, but it should be allowed to,
			canMove = true;						//set canMove to true to allow it to move again.

		if(canMove){																						//If the slinger is able to move,
			playerDetected = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);//try to find a player based on the playerCheckVariable, in the "whatIsPlayer"
			rigidbody2D.velocity = moveDirection * slow;													//layer, and set the Slingers velocity to the moveDirection variable.

			if(playerDetected){											//If a player has been detected.
				if(fireTimer < 0.4f){									//if the fireTimer variable is less than 0,4
					moveTimer = 0.19f;									//set the moveTimer variable to 0.19
					animator.SetBool("isShooting", true);				//and animate the shooting animation of the slinger.
				}
				if(canFire){											//If the Slinger is allowed to shoot at the player,
					Fire(playerDetected.transform.position);			//shoot at the player using the Fire function,
					canFire = false;									//don't allow the slinger to shoot again for another
					fireTimer = 3f;										//3 seconds,
					animator.SetBool("isShooting", false);				//and stop the shooting animation.
				}
			}
			if(fireTimer < 0f){		//If the fireTimer variable is less than 0,
				fireTimer = 0f;		//set it back to 0
				canFire = true;		//and allow the Slinger to shoot at the player.
			}
			if (moveTimer < 0f){									//If the moveTimer variable is less than 0 seconds (if the Slinger should move in a new direction),
				moveDirection = NextMove();							//change the Slingers movement direction using the NextMove function,
				moveTimer = Random.Range (minMoveWait, maxMoveWait);//and change the movement again after minMoveWait to maxMoveWait seconds (0,6 and 1,5 at the time of writing).
			}
			if(moveTimer < 0.2f)									//If the moveTimer variable is less than 0.2,
				moveDirection = new Vector2(0, 0);					//stop the Slinger from moving.

			fireTimer -= Time.deltaTime;							//Decrease the fireTimer by the change in time, and
			moveTimer -= Time.deltaTime;							//do the same for the moveTimer.
		}

		if(slowDuration < Time.time)								//If the Slinger shouldn't be slowed anymore,
			slow = 1f;												//stop it from being slowed.
		if(immunityCD > Time.time)									//If the Slinger has sustained damage and is now immune,
			animator.SetBool("isDamaged", true);					//animate the Slinger taking damage,
		else 														//otherwise, don't.
			animator.SetBool("isDamaged", false);
	}

	protected override void OnCollisionEnter2D(Collision2D other){	//If the Slinger has collided with something,
		moveDirection = -moveDirection;								//move in the opposite direction that it currently is.
		if(other.gameObject.tag == "Player"){						//If the Slinger collided with a player,
			dealDamage(other.gameObject, 5, true, 50);				//deal 5 damage to the player, and knock it back with a force of 50.
		}
	}

	void Fire(Vector2 playerPos){									//Function for shooting at the player.
		Rigidbody2D clone;											//Make a clone of the projectile the Slinger is shooting,
		float angle = Mathf.Atan2(playerCheck.position.y - playerPos.y, playerCheck.position.x - playerPos.x);//calculate the angle between the Slinger and the Player,
		clone = Instantiate(projectile, transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * -0.9f, transform.rotation) as Rigidbody2D;//Create the projectile,
		clone.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * -20f;//and shoot it towards the player.
	}

	Vector2 NextMove(){								//Function for changing the Slinger direction of movement.
		int r = Random.Range (1, 5);				//Gets a random number from 1 to 5, and then changes the
		switch(r){									//direction based on that number.
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
