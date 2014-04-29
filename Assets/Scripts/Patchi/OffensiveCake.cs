﻿using UnityEngine;
using System.Collections;

public class OffensiveCake : Projectile {
	

	// Declaration of the variables.

	float TimeCake = -1f;

	bool CakeFireOne = true;
	bool CakeFireTwo = true;
	bool CakeFireThree = true;
	bool CakeFireFour = true;

	public GameObject AttackCake;
	public Transform PosA;
	public Transform PosB;
	public Transform PosC;
	public Transform PosD;


	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.52f);		// Destory the object after 0.52f
		TimeCake = 0.5f + Time.time;					// setting a timer for an if-statement in the update
	}
	
	// Update is called once per frame
	void Update () {
		if(TimeCake < Time.time)
		{

			// After 0.5f the cake will be destoryed and split into four pieces

			if(CakeFireOne == true)
			{
			GameObject Cake = Instantiate(AttackCake, PosA.position, PosA.rotation) as GameObject;						// Same method as in the Patchi Script
			Cake.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f)),
			                                        Mathf.Sin((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 3f;
				CakeFireOne = false;
			}

			if(CakeFireTwo == true)
			{
			GameObject CakeTwo = Instantiate(AttackCake, PosB.position, PosB.rotation) as GameObject;
			CakeTwo.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
			                                           Mathf.Sin((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 3f;
				CakeFireTwo = false;
			}

			if(CakeFireThree == true)
			{
				GameObject CakeThree = Instantiate(AttackCake, PosC.position, PosC.rotation) as GameObject;
				CakeThree.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z - 135f) * (Mathf.PI / 180f)),
				                                           Mathf.Sin((transform.eulerAngles.z - 135f) * (Mathf.PI / 180f))) * 3f;
				CakeFireThree = false;
			}

			if(CakeFireFour == true)
			{
				GameObject CakeFour = Instantiate(AttackCake, PosD.position, PosD.rotation) as GameObject;
				CakeFour.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z - 45f) * (Mathf.PI / 180f)),
				                                             Mathf.Sin((transform.eulerAngles.z - 45f) * (Mathf.PI / 180f))) * 3f;
				CakeFireFour = false;
			}
			
		}
			
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 50, true, 10);					// If an enemy gets hit it will take damage and knockback
	}
}

