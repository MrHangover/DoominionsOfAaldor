using UnityEngine;
using System.Collections;

public class Patchi : Player {
	
	public Animator animator;

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

		maxSpeed = 15f;
		maxHealth = 50;
		health = 50;

		Speech = false;


		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetFloat("vSpeed", Mathf.Abs(moveV));
		animator.SetFloat("hSpeed", Mathf.Abs(moveH));
		

		if(SpeedTime < Time.time && UltTime < Time.time )
		{
			maxSpeed = 5f;
		}

		if(!Speech)
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


	void CDAttackCake() {
		normalCD = 0.5f + Time.time;

		return;
	}

	void CDDefBall() {
		defensiveCD = 5.0f + Time.time;
		
		return;
	}

	void CDAttackSpell() {
		offensiveCD = 5.0f + Time.time;
		
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

	protected override void NormalAttack(){

		if(normalCD < Time.time)
		{
			GameObject Cake = Instantiate(AttackCake, AttackCakePos.position, AttackCakePos.rotation) as GameObject;
			Cake.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                        Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
			CDAttackCake();
		}

	}

	protected override void OffensiveAbility(){

		if(offensiveCD < Time.time)
		{
			CDAttackSpell();
			GameObject Attack = Instantiate(AttackBall, AttackBallPos.position, AttackBallPos.rotation) as GameObject;
			Attack.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                          Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 6f;

		}

	}
	
	protected override void DefensiveAbility(){

		if(defensiveCD < Time.time)
		{
			GameObject Def = Instantiate(DefBall, DefBallPos.position, DefBallPos.rotation) as GameObject;
			CDDefBall();
		}

	}
	
	protected override void MovementAbility(){

		if(movementCD < Time.time && UltTime < Time.time)
		{
			maxSpeed = 15f;
			SpeedTimer();
			CDSpeed();
		}

	}
	
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