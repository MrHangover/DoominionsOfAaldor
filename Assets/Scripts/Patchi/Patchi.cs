using UnityEngine;
using System.Collections;

public class Patchi : Player {


	// Declaration of the variables.

	Animator animator;

	float SpeedTime = 0;	
	float UltTime = 0;		

	public GameObject DefBall;
	public Transform DefBallPos;

	public GameObject AttackCake;
	public Transform AttackCakePos;

	public GameObject AttackBall;
	public Transform AttackBallPos;

	public GameObject Nova;
	public Transform NovaPos;
	

	// Use this for initialization
	void Start () {

		// Setting up health and speed from player, setting speech to false and getting the animator

		maxSpeed = 5f;
		maxHealth = 100;
		health = 100;

		Speech = false;


		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		// Sending information about if i walk up/down or left/right

		animator.SetFloat("vSpeed", Mathf.Abs(moveV));	// sending moveV values into vSpeed getting the values from player script
		animator.SetFloat("hSpeed", Mathf.Abs(moveH));	// sending moveH values into HSpeed getting the values from player script
		

		if(SpeedTime < Time.time && UltTime < Time.time )
		{
			maxSpeed = 5f; // After speed increase and ult stun the speed will be set to 5f
		}

		if(!Speech)
		{
		
		// Inputs that starts the named function

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
		

		// Setting Cooldowns
		
		if(offensiveCD > Time.time)
		{
			UIOffensiveCD = true;
		} else {
			UIOffensiveCD = false;
			}

		if(defensiveCD > Time.time)
		{
			UIDefensiveCD = true;
		} else {
				UIDefensiveCD = false;
			}

		if(movementCD > Time.time)
		{
			UIMovementCD = true;
		} else {
				UIMovementCD = false;
			}

		if(ultCD > Time.time)
		{
			UIUltCD = true;
		} else {
				UIUltCD = false;
			}
		
		
		
		
		}
		
	}

	// Adding time to the CD tracker

	void CDAttackCake() {
		normalCD = 0.4f + Time.time;	// adding time to the spell only can be used every 0.5f

		return;
	}

	void CDDefBall() {
		defensiveCD = 3.0f + Time.time;
		
		return;
	}

	void CDAttackSpell() {
		offensiveCD = 2.0f + Time.time;
		
		return;
	}

	void CDSpeed() {
		movementCD = 10.0f + Time.time;
		
		return;
	}

	void SpeedTimer() {
		SpeedTime = 4.0f + Time.time;
		
		return;
	}

	void CDUlt() {
		ultCD = 60.0f + Time.time;
		
		return;
	}

	void UltTimer() {
		UltTime = 2.0f + Time.time;
		
		return;
	}

	// a function that fires the normal attack.. spawns a piece of cake :D

	protected override void NormalAttack(){

		if(normalCD < Time.time)
		{
			GameObject Cake = Instantiate(AttackCake, AttackCakePos.position, AttackCakePos.rotation) as GameObject; // spawns the gameobejct by the assigned position and rotation
			Cake.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),	// adding force to the spawned object based on the rotation from sin and cos
			                                        Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
			CDAttackCake();
		}

	}

	// a function that spawns a larger cake that splits into smaller pieces :D

	protected override void OffensiveAbility(){

		if(offensiveCD < Time.time)
		{
			CDAttackSpell();
			GameObject Attack = Instantiate(AttackBall, AttackBallPos.position, AttackBallPos.rotation) as GameObject; // Same as above
			Attack.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                          Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 6f;

		}

	}

	// a function that spawns a ball that the player can hide behind. 

	protected override void DefensiveAbility(){

		if(defensiveCD < Time.time)
		{
			GameObject Def = Instantiate(DefBall, DefBallPos.position, DefBallPos.rotation) as GameObject;
			CDDefBall();
		}

	}

	// a function that increase the players movement speed

	protected override void MovementAbility(){

		if(movementCD < Time.time && UltTime < Time.time)
		{
			maxSpeed = 10f;
			SpeedTimer();
			CDSpeed();
		}

	}

	 // a function that spawns a nova around the player

	protected override void UltAbility(){

		if (ultCD < Time.time)
		{
			maxSpeed = 0f;
			GameObject Ult = Instantiate(Nova, NovaPos.position, NovaPos.rotation) as GameObject;
			CDUlt();
			UltTimer();
		}

	}

}