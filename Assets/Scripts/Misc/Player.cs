using UnityEngine;
using System.Collections;

public abstract class Player : Creature {

	public static bool facingRight = true;
	public static bool Speech;
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
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");

		if(canMove){
			rigidbody2D.velocity = new Vector2(moveH * maxSpeed * slow, moveV * maxSpeed * slow);
		}

		if(rigidbody2D.velocity.x != 0f || rigidbody2D.velocity.y != 0f){
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * (180f / Mathf.PI) - 90f);
			if(transform.eulerAngles.z < 360f)
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360f);
		}

		if(!canMove && stunnedCD < Time.time)
			canMove = true;

		if(slowDuration < Time.time)
			slow = 1f;
	}

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
