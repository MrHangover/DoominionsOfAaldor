using UnityEngine;
using System.Collections;

public class Patchi : Player {
	
	public Animator animator;

	float DefBallCD = 0;
	float AttackCakeCD = 0;
	float AttackBallCD = 0;
	float SpeedCD = 0;
	float SpeedTime = 0;
	float UltCD = 0;
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


		if(Input.GetButtonDown("Normal"))
		{

			if(AttackCakeCD < Time.time)
			{
				GameObject Cake = Instantiate(AttackCake, AttackCakePos.position, AttackCakePos.rotation) as GameObject;
				Cake.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
				                                        Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
				CDAttackCake();
			}
		}

		if(Input.GetButtonDown("Speed"))
		{

			if(SpeedCD < Time.time && UltTime < Time.time)
			{
				maxSpeed = 20f;
				SpeedTimer();
				CDSpeed();
			}


		}


		if(Input.GetButtonDown("Defensive"))
		{
			if(DefBallCD < Time.time)
			{
				GameObject Def = Instantiate(DefBall, DefBallPos.position, DefBallPos.rotation) as GameObject;
				CDDefBall();
			}
		}

		if(Input.GetButtonDown("Offensive"))
		{
			if(AttackBallCD < Time.time)
			{
				GameObject Attack = Instantiate(AttackBall, AttackBallPos.position, AttackBallPos.rotation) as GameObject;
				CDAttackBall();
				Attack.rigidbody2D.velocity = new Vector2(Mathf.Cos(transform.eulerAngles.z * (Mathf.PI / 180f)),
				                                          Mathf.Sin(transform.eulerAngles.z * (Mathf.PI / 180f))) * 20f;
			}
		}

		if(Input.GetButtonDown("Ult"))
		{
			if (UltCD < Time.time)
			{
				maxSpeed = 0f;
				GameObject Ult = Instantiate(Nova, NovaPos.position, NovaPos.rotation) as GameObject;
				CDUlt();
				UltTimer();
			}
		}
	}


	void CDAttackCake() {
		AttackCakeCD = 0.5f + Time.time;

		return;
	}

	void CDDefBall() {
		DefBallCD = 5.0f + Time.time;
		
		return;
	}

	void CDAttackBall() {
		AttackBallCD = 5.0f + Time.time;
		
		return;
	}

	void CDSpeed() {
		SpeedCD = 10.0f + Time.time;
		
		return;
	}

	void SpeedTimer() {
		SpeedTime = 4.0f + Time.time;
		
		return;
	}

	void CDUlt() {
		UltCD = 60.0f + Time.time;
		
		return;
	}

	void UltTimer() {
		UltTime = 2.0f + Time.time;
		
		return;
	}

	protected override void NormalAttack(){

	}

	protected override void OffensiveAbility(){

	}
	
	protected override void DefensiveAbility(){

	}
	
	protected override void MovementAbility(){

	}
	
	protected override void UltAbility(){

	}

}