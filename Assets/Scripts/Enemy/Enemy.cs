//<Summary>
//This is the base class for all enemies in the game.
//It contains a function for dealing damage to the player, and
//requires and extension of the class to implement and OnCollitionEnter2D function.
//It also extends from the Creature class.
//</Summary>

using UnityEngine;
using System.Collections;

public abstract class Enemy : Creature {	//Extends from the creature class.

	protected abstract void OnCollisionEnter2D(Collision2D other);	//Forces any scripts extending this script to implement an OnCollisionEnter2D function.

	protected void dealDamage(GameObject player, int damage, bool isKnockBacking, int knockBackForce = 0){	//Function for dealing damage and knocking back the player (or other GameObjects).
		Creature playerScript = player.GetComponent<Creature>();		//Finds the Creature class in the GameObject specified, 
		playerScript.TakeDamage(damage);								//deals the specified damage to that class, and if the script should
		if(isKnockBacking){												//knock the GameObject back, do so with the specified force, based on this gameObjects position, and the
			float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);//specified GameObjects position.
			playerScript.KnockBack(new Vector2(Mathf.Cos(angle) * -knockBackForce, Mathf.Sin(angle) * -knockBackForce));
		}
	}
}