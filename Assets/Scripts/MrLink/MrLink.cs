//<Summary>
//
//
//
//
//
//
//</Summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MrLink : Player {							//Extends the Player class.

	//Creating variables
	List<GameObject> teleYos = new List<GameObject>();	
	int defStacks = 5;
	Animator yoAnimator;
	Animator linkAnimator;
	Animator[] animators;
	public GameObject ultYo;
	public GameObject teleYo;
	public GameObject defYo;
	float ultActiveTime = -1f;
	float defStackTime = 0f;
	
	void Start () {
		maxSpeed = 20f;									//Assigning values to the players max speed
		maxHealth = 80;									//and health.
		health = maxHealth;
		animators = GetComponentsInChildren<Animator>();//Finding animator components in children and the current GameObject.
		yoAnimator = animators[1];						//Assigning these animators to variables.
		linkAnimator = animators[0];
	}
	
	// Update is called once per frame
	void Update () {

		//Gets input from the user and activates the according function, based on what button the user pressed.
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

		if(ultActiveTime >= Time.time){												//If the player is ulting
			maxSpeed = Mathf.Lerp(0f, 60f, (15f - (ultActiveTime - Time.time))/15f);//maxSpeed will start at 0 and then slowly go to 60 after 15 seconds.
		}

		if(maxSpeed > 20f){											//If the players maxspeed is greater than 20,
			if(ultActiveTime < Time.time){							//and the player isn't using his ult ability anymore
				maxSpeed = 20f;										//set the maxspeed back to 0
				linkAnimator.SetBool("isUlting", false);			//and tell the animator that the player is no longer using his ult.
			}
		}

		if(defStackTime <= Time.time && defStacks < 5){				//Gives the player another stack of his defensive ability if defStackTime is less than the current time,
			defStacks++;											//and the player doesn't have 5 or more stacks.
			defStackTime = Time.time + 10f;							//Then set the defStackTime to the current time + seconds (so it reactivates in 10 seconds).
		}

		if(immunityCD > Time.time && ultActiveTime < Time.time)		//If the player is immune (has taken damage),
			linkAnimator.SetBool("isDamaged", true);				//tell the animator to animate the character taking damage
		else 														//
			linkAnimator.SetBool("isDamaged", false);				//otherwise, don't animate the character taking damage.


		// UI stuff

		if(offensiveCD > Time.time)
		{
			UIOffensiveCD = true;
		} else {
			UIOffensiveCD = false;
		}
		
		if(defStacks == 0)
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

		// UI stuff end
	}

	protected override void NormalAttack(){		//Function for this characters normal attack.
		if(normalCD <= Time.time){				//If the player is able to use it's normal attack,
			yoAnimator.SetTrigger("attack");	//animate the attack (this executes the attack),
			normalCD = Time.time + 0.5f;		//and wait 0.5 seconds before allowing the player to use the normal attack again.
		}
	}

	protected override void OffensiveAbility(){	//Function for the players offensive ability
		if(offensiveCD <= Time.time){			//If the player is able to use its offensive ability,
			offensiveCD = Time.time + 2.5f;		//don't allow the player to use the ability again for 2,5 seconds,
			GameObject tele = Instantiate(teleYo, //instantiate a "teleYo" projectile, and shoot it in the correct direction based on the players rotation
			                              transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), 0f) * 1.2f,
			                              transform.rotation) as GameObject;
			tele.rigidbody2D.AddForce(new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 400f
			                          + rigidbody2D.velocity * 20f);
			tele.rigidbody2D.AddTorque(20f);//Add some Torque (rotation) to the fired projectile.
			teleYos.Add(tele);				//Add the spawned projectile to the teleYos list. This will be used in the players movement ability.
			if(teleYos.Count > 8)			//If there's more than 8 projectiles in the list,
				teleYos.RemoveAt(0);		//remove the first one (this is the "oldest" projectile).
		}
	}
	
	protected override void DefensiveAbility(){			//Function for the players defensive ability.
		if(defStacks > 0 && defensiveCD < Time.time){	//If the player should be able to use the defensive ability,
			defensiveCD = Time.time + 0.5f;				//don't allow the player to use the ability again for 0.5 seconds
			GameObject def = Instantiate(defYo, transform.position + new Vector3(0f, 2f, 0f), transform.rotation) as GameObject;	//Spawn a "defYo" GameObject
			defStacks--;								//decrese the defensive stacks by 1,
			Destroy(def, 10f);							//and destroy the defYo object after 10 seconds.
		}
	}
	
	protected override void MovementAbility(){			//Function for the players movement ability.
		if(movementCD <= Time.time){					//If the player is able to use the ability,
			movementCD = Time.time + 1f;				//don't allow the player to use the ability again for 1 second.
			GameObject telePos = null;					//Create a GameObject variable called telePos, and set it to null.
			foreach(GameObject o in teleYos)			//Go through all GameObjects in the teleYos list,
				telePos = o;							//and set the telePos variable to the current GameObject in the teleYos list (this will end at the last GameObject in the list).
			if(telePos){								//If the last GameObject found in the list wasn't null,
				transform.position = telePos.transform.position;//teleport to the position of the telePos GameObject,
				teleYos.Remove(telePos);				//Remove that object from the list,
				Destroy(telePos);						//and remove it from the scene.
			}
		}
	}
	
	protected override void UltAbility(){				//Function for the players ult ability.
		if(ultCD <= Time.time){							//If the player is able to use the abilty,
			Stun(1f);									//Stun the player for 1 second (don't allow the player to move).
			rigidbody2D.velocity = Vector2.zero;		//Set the players velocity to 0 so the player stands still.
			ultCD = 60f + Time.time;					//Don't allow the player to use the ability again for 60 seconds.
			ultActiveTime = 16f + Time.time;			//Use the ability for 16 seconds.
			immunityCD = 16f + Time.time;				//Make the player immune to damage for 16 seconds.
			knockBackCD = 16f + Time.time;				//Make the player immune to knockbacks for 16 seconds.
			slowCD = 16f + Time.time;					//Make the player immune to slows for 16 seconds.
			linkAnimator.SetBool("isUlting", true);		//Tell the animator that the player is ulting.
			linkAnimator.SetTrigger("ult");				//Animate the player using the ult ability
			GameObject bigYo = Instantiate(ultYo, transform.position, transform.rotation) as GameObject;//Instantiate a big yoyo beneath the player.
			bigYo.transform.parent = transform;			//Set the big yoyo's parent to the be the player.
			Destroy(bigYo, 16f);						//Remove the big yoyo from the scene after 16 seconds.
		}
	}
}
