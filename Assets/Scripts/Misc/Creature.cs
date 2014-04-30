//<Summary>
//This is the base class for all living things in the game. All basic functionalities
//for taking damage, getting slowed, getting knockbacked and getting stunned are included here.
//</Summary>

using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour { //Class is abstract as it is used as a base-class.

	//Declaration of variables. Some variables will get its values in other scripts.
	protected float maxSpeed;
	protected int health;
	protected int maxHealth;
	protected bool canMove = true;
	protected float slowCD = 0f;
	protected float slowDuration = 1f;
	protected float slow = 1f;
	protected float stunnedCD = 0f;
	protected float immunityCD = 0f;
	protected float knockBackCD = 0f;
	public int HealthTracker;
	
	public void TakeDamage(int damage){		//Function for taking damage or gaining health. It's public so other scripts can call it.
		if(immunityCD < Time.time){			//Can only take damage when the creature isn't immune.
			health -= damage;				//Decreases health by the damage dealth.
			if(health > maxHealth)			//Ensures that the health cannot exceed maxHealth in case the creature gained some health.
				health = maxHealth;			//
			if(health < 1)					//Destroys the creature this script is attached to, if its health is below 1.
				Destroy(gameObject);		//
			immunityCD = Time.time + 0.25f;	//Makes the creature immune for 0.25 seconds after damage has been sustained.
		}									//This ensures that the creature can't die immediately by being stuck in something that deals damage.
	}
	
	public void KnockBack(Vector2 force){	//Function for knocking back the creature by the ammount specified in a Vector2 variable called force.
		if(knockBackCD < Time.time){		//Knockback has a cooldown as well, since it seems unfair if the player dies from being knocked around between creatures.
			Stun (0.25f);					//Calls the stun function, which makes sure the creature can't move when it is knocked back.
			rigidbody2D.velocity = force;	//Knocks the creature back.
			immunityCD = Time.time + 0.5f;	//Makes the creature immune to damage for 0.5 seconds.
			knockBackCD = Time.time + 0.5f;	//Makes the creature immune to knockbacks for 0.5 seconds.
		}
	}
	
	public void Stun(float duration){		//Function for stunning the creature. The creature can still be knocked around, but can't move by itself.
		canMove = false;					//Sets the canMove boolean to false. Other scripts have to implement a method for stopping movement by themself.
		stunnedCD = duration + Time.time;	//Used by other scripts to re-enable the canMove variable.
	}

	public void Slow(float duration, float amount){	//Function used for slowing creatures by the duration, and with an amount between 0 and 1 (0 being no slow, 1 being unable to move).
		if(slowCD < Time.time){				//Ensures that the creature can only be slowed it isn't currently immune to slows.
			slowDuration = Time.time + duration;	//Slows by the specified duration.
			slow = 1f - amount;				//Calculates the slow amount.
			slowCD = Time.time + 0.5f;		//Ensures that the creature can't be slowed for 0.5 seconds. The functionality is implemented in other scripts.
		}
	}
}
