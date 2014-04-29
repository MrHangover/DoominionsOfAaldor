//<Summary>
//This is the projectile class, which should be used by all flying object that collides with walls and such.
//It contains a function for dealing damage, reflecting other projectiles, kncking back itself,
//and slowing it's target.
//</Summary>

using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	float damageCD = 0f;

	public void KnockBack(Vector2 force){	//Function for knocking back itself. It's public so it can be called by other scripts.
		rigidbody2D.velocity = force;		//Knocks itself back based on the specified force.
	}

	protected abstract void OnCollisionEnter2D(Collision2D other);	//Forces any scripts that extends from this script to implement an OnCollisionEnter2D function.

	protected void dealDamage(GameObject player, int damage, bool isKnockBacking, int knockBackForce = 0){	//Function for dealing damage to a GameObject.
		if(damageCD < Time.time){																		 	//If it should be able to deal damage,
			Creature playerScript = player.GetComponent<Creature>();										//find the other GameObject's script,
			playerScript.TakeDamage(damage);																//deal damage to it, and if it should be knocked back,
			if(isKnockBacking){																				//do so with the specified force.
				float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);
				playerScript.KnockBack(new Vector2(Mathf.Cos(angle) * -knockBackForce, Mathf.Sin(angle) * -knockBackForce));
			}
			damageCD = Time.time + 0.25f;
		}
	}

	protected void reflectProjectile(GameObject projectile, Vector2 knockBack){	//Function for knocking back other projectiles.
		Projectile projectileScript = projectile.GetComponent<Projectile>();	//Knocks the other projectile back by the specified Vector2.
		projectileScript.KnockBack(knockBack);
	}

	protected void Slow(GameObject target, float duration, float amount){		//Function for slowing other GameObjects.
		Creature enemy = target.GetComponent<Creature>();						//Slows the specified GameObject by the duration and
		enemy.Slow(duration, amount);											//amount specified.
	}
}
