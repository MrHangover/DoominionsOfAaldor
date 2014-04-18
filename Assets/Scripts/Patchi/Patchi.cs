using UnityEngine;
using System.Collections;

public class Patchi : Player {
	

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

	
	}
	
	// Update is called once per frame
	void Update () {
	

		if(SpeedTime < Time.time && UltTime < Time.time )
		{
			maxSpeed = 5f;
		}


		if(Input.GetButtonDown("Fire1"))
		{

			if(AttackCakeCD < Time.time)
			{
				GameObject Cake = Instantiate(AttackCake, AttackCakePos.position, AttackCakePos.rotation) as GameObject;
				CDAttackCake();
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{

			if(SpeedCD < Time.time && UltTime < Time.time)
			{
				maxSpeed = 15f;
				SpeedTimer();
				CDSpeed();
			}


		}


		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			if(DefBallCD < Time.time)
			{
				GameObject Def = Instantiate(DefBall, DefBallPos.position, DefBallPos.rotation) as GameObject;
				CDDefBall();
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(AttackBallCD < Time.time)
			{
				GameObject Attack = Instantiate(AttackBall, AttackBallPos.position, AttackBallPos.rotation) as GameObject;
				CDAttackBall();
			
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
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

	protected override void OffensiveAbility(){

	}
	
	protected override void DefensiveAbility(){

	}
	
	protected override void MovementAbility(){

	}
	
	protected override void UltAbility(){

	}

}