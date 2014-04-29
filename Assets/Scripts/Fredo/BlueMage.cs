using UnityEngine;
using System.Collections;

public class BlueMage : Player { //The class "BlueMage" is a "Player"

	//Animator blueAnimator;
	public Animator animator;
	BoxCollider2D boxCollider2D;
	public GameObject ultBlue;
	float moveActiveTime = -1f;
	float AttackIceCD = 0;
	//The various animators, boxcolliders and variables used throughout the script



	public GameObject AttackIce;
	public Transform AttackIcePos;
	public GameObject AttackOrb;
	public Transform AttackOrbPos;
	public GameObject AttackStorm;
	public Transform AttackStormPos;
	public GameObject icePart;
	public Transform icePartPos;
								// References is assigned to the various gameobjects and transforms used in the code, determining the different prefabs and spawn points
	public GameObject Nova;
	public Transform NovaPos1;
	public Transform NovaPos2;
	public Transform NovaPos3;
	public Transform NovaPos4;
	public Transform NovaPos5;
	public Transform NovaPos6;
	public Transform NovaPos7;
	public Transform NovaPos8;
	public Transform NovaPos9;
	public Transform NovaPos10;
	public Transform NovaPos11;
	public Transform NovaPos12;
	public Transform NovaPos13;
	public Transform NovaPos14;
	public Transform NovaPos15; //Aaand a gazillion spawnpoints for the nova




	// Use this for initialization
	void Start () {
		maxSpeed = 5f; //The starting "stats" for the bluemage - health, movement speed etc.
		maxHealth = 85;
		health = 85;
		animator = GetComponent<Animator>();
		//blueAnimator = animator[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Normal"))
			NormalAttack();
		if(Input.GetButton("Offensive"))
			OffensiveAbility();
		if(Input.GetButton("Defensive"))
			DefensiveAbility();
		if(Input.GetButton("Speed"))
			MovementAbility();
		if(Input.GetButton("Ult"))
			UltAbility(); //The buttons for the different spells - These are assigned on the "base" player class

		animator.SetFloat("vSpeed", Mathf.Abs(moveV));
		animator.SetFloat("hSpeed", Mathf.Abs(moveH));

		if(moveActiveTime >= Time.time){
			maxSpeed = Mathf.Lerp(5f, 20f, (7f - (moveActiveTime - Time.time))/7f);
			InvokeRepeating("IcePart",1f,1.5f);
		} //This is used for the movement ability: When the spell is activated, the speed of the player will gradually increase from 5 to 20 (at a rate of roughly 2.14f / sec)
			// Every time the function is run, it will also call the "InvokeRepeating" function, meaning that the function "IcePart" will be called after 1 second, and then again every 1.5 seconds
				// This is called multiple times throughout the function, making the effect gradually more intense
		if(maxSpeed > 5f){
			if(moveActiveTime < Time.time){
				maxSpeed = 5f;
				CancelInvoke("IcePart");
			} //Once the movement ability expires, the mage's movementspeed will be reset to 5 and the "CancelInvoke" function will be called, stopping the spawning of ice particles
		}

		// UI stuff
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

		//UI stuff end
	}
	void CDAttackIce () {
		normalCD = 0.5f + Time.time;
		
		return; //The cooldown of the basic attack is 0.5 seconds (to prevent it from being spammable)
	}

	private void IcePart(){
		GameObject IceParticle = Instantiate(icePart, icePartPos.position + new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-0.9f, 0.9f), 0), icePartPos.rotation) as GameObject;
		IceParticle.rigidbody2D.AddForce(transform.parent.transform.parent.rigidbody2D.velocity * 8f + 
		                         new Vector2(Mathf.Cos((transform.eulerAngles.z - 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z - 90f) * (Mathf.PI / 180f))) * 100f);
		} //This is the function called by the movementspeed ability to generate small ice particles around the player, in a random pattern

	protected override void NormalAttack(){
		if(normalCD <= Time.time){

			GameObject IceShard = Instantiate(AttackIce, AttackIcePos.position, AttackIcePos.rotation) as GameObject;
			IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 25f;
			CDAttackIce();
			normalCD = Time.time + 0.5f;
		} //When the player presses the basic attack button, a projectile of the type "IceShard" will be fired from the spawnpoin allocated (in front of the mage)
			//It moves at a speed of 25.
	}

	protected override void OffensiveAbility(){
		if(offensiveCD <= Time.time){

			GameObject OrbofIce = Instantiate(AttackOrb, AttackOrbPos.position, AttackOrbPos.rotation) as GameObject;
			OrbofIce.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 7f;

			//When the offensive ability is activated, a frozen orb will spawn in front of the player - it will travel at 7 speed
			// This ability have a 7.5 seconds cooldown
			offensiveCD = Time.time + 7.5f;

		}
	}
	
	protected override void DefensiveAbility(){
		if(defensiveCD <= Time.time){
				GameObject NovaShard1 = Instantiate(Nova, NovaPos1.position, NovaPos1.rotation) as GameObject;
				NovaShard1.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard2 = Instantiate(Nova, NovaPos2.position, NovaPos2.rotation) as GameObject;
				NovaShard2.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 112.5f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 112.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard3 = Instantiate(Nova, NovaPos3.position, NovaPos3.rotation) as GameObject;
				NovaShard3.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard4 = Instantiate(Nova, NovaPos4.position, NovaPos4.rotation) as GameObject;
				NovaShard4.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 157.5f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 157.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard5 = Instantiate(Nova, NovaPos5.position, NovaPos5.rotation) as GameObject;
				NovaShard5.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard6 = Instantiate(Nova, NovaPos6.position, NovaPos6.rotation) as GameObject;
				NovaShard6.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 202.5f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 202.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard7 = Instantiate(Nova, NovaPos7.position, NovaPos7.rotation) as GameObject;
				NovaShard7.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard8 = Instantiate(Nova, NovaPos8.position, NovaPos8.rotation) as GameObject;
				NovaShard8.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 247.5f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 247.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard9 = Instantiate(Nova, NovaPos9.position, NovaPos9.rotation) as GameObject;
				NovaShard9.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
				                                              Mathf.Sin((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard10 = Instantiate(Nova, NovaPos10.position, NovaPos10.rotation) as GameObject;
				NovaShard10.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 285.5f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 285.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard11 = Instantiate(Nova, NovaPos11.position, NovaPos11.rotation) as GameObject;
				NovaShard11.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard12 = Instantiate(Nova, NovaPos12.position, NovaPos12.rotation) as GameObject;
				NovaShard12.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 1f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 1f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard13 = Instantiate(Nova, NovaPos13.position, NovaPos13.rotation) as GameObject;
				NovaShard13.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 22.5f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 22.5f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard14 = Instantiate(Nova, NovaPos14.position, NovaPos4.rotation) as GameObject;
				NovaShard14.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 20f;
				GameObject NovaShard15 = Instantiate(Nova, NovaPos15.position, NovaPos15.rotation) as GameObject;
				NovaShard15.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 67.5f) * (Mathf.PI / 180f)),
				                                               Mathf.Sin((transform.eulerAngles.z + 67.5f) * (Mathf.PI / 180f))) * 20f;
			// When the defensive ability button is pressed, 15 projectiles will fire from different spawnpoints around the mage, creating a "nova"
			//They fire at a speed of 20, and the ability have a 10 second cooldown
			defensiveCD = Time.time +10f;
		}
	}
	
	protected override void MovementAbility(){
		if(movementCD <= Time.time){

			moveActiveTime = 7f + Time.time;
			//The ability is active for 7 seconds

			movementCD = Time.time+32f; //It has a 32 seconds cooldown - which translates into 25 seconds, after the last activation has expired
			//When the movement speed ability is activated, it will set the moveActiveTime variable to 16(+time), which in turn activates the associated speed increase and particle spawners
		}
	}
	
	protected override void UltAbility(){
		if(ultCD <= Time.time){
			GameObject HailStorm = Instantiate(AttackStorm, AttackStormPos.position, AttackStormPos.rotation) as GameObject;
			HailStorm.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                             Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 0f;
			CDAttackIce();
			ultCD = Time.time + 45f;
			//When the ultimate ability is activated, a ring of frost will spawn centered around the player, and will follow him for the duration
			//It has a 45 seconds cooldown
		}
	}
}