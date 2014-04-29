//<Summary>
//The player class is used for all creatures that can be controlled by the user.
//This script forces all extensions of this class to implement 5 abilites and their functionality.
//It also contains movement control and some cooldown variables for use by scripts that extends this script.
//This script exends the creature script, and has all its functionalities.
//</Summary>

using UnityEngine;
using System.Collections;

public abstract class Player : Creature {

	//Creation of variables.
	protected float moveH;
	protected float moveV;
	protected float normalCD = -1f;
	protected float offensiveCD = -1f;
	protected float movementCD = -1f;
	protected float defensiveCD = -1f;
	protected float ultCD = -1f;
	public static bool UIOffensiveCD = false;
	public static bool UIMovementCD = false;
	public static bool UIDefensiveCD = false;
	public static bool UIUltCD = false;
	public static bool facingRight = true;
	public static bool Speech;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		moveH = Input.GetAxis ("Horizontal");		//Takes input from the horizontal axis (buttons A and D)
		moveV = Input.GetAxis ("Vertical");			//Takes input from the vertical axis (buttons W and S)

		if(canMove){																				//If the player is allowed to moved, change it's velocity based on input,
			rigidbody2D.velocity = new Vector2(moveH * maxSpeed * slow, moveV * maxSpeed * slow);	//slow and max speed.
		}

		if(rigidbody2D.velocity.x != 0f || rigidbody2D.velocity.y != 0f){			//If the player is moving in a direction.
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * (180f / Mathf.PI) - 90f); //Calculates rotation based on velocity
			if(transform.eulerAngles.z < 360f)																									//and rotates the player.
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360f);													//If rotation if below 0 degrees, change
		}																																		//rotation accordingly

		if(!canMove && stunnedCD < Time.time)		//If the player can't move, but should be able to,
			canMove = true;							//allow the player to move.

		if(slowDuration < Time.time)				//If the player shouldn't be slowed anymore,
			slow = 1f;								//cancel any slow.
	}

	//Update will be overridden by other players, as they need to implement the abilities themselves, however this short amount of code was left here so you could always
	//go back and look at what should be implemented.
	void Update ()
	{
		if(Input.GetButton("Normal"))
			NormalAttack();
		if(Input.GetButton("Offensive"))
			OffensiveAbility();
		if(Input.GetButton("Defensive"))
			DefensiveAbility();
		if(Input.GetButton("Speed"))
			MovementAbility();
		if(Input.GetButton("Ult"))
			UltAbility();
	}

	//Abstract functions must be implemented in all scripts that extends the player. This ensures that all players has abilities implemented.
	protected abstract void NormalAttack();

	protected abstract void OffensiveAbility();

	protected abstract void DefensiveAbility();

	protected abstract void MovementAbility();

	protected abstract void UltAbility();
	
	public void Speechset() {
		if(Speech == false)
		{
			Speech = true;
		} else {
			Speech = false;
		}
	}
}
