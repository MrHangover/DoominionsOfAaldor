﻿//<Summary>
//Base class for all Weapons. A weapon is anything that should be able to interact with creatures, but 
//doesn't collide with them. This class contains functions for dealing damage, reflecting projectiles, and
//slowing. The script is extremely similar to the Projectile.cs script, so it won't be explained in detail here.
//Read the comments in the Projectile.cs script instead.
//</Summary>

using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	float damageCD = 0f;
	
	protected abstract void OnTriggerEnter2D(Collider2D other);
	

	protected void dealDamage(GameObject player, int damage, bool isKnockBacking, int knockBackForce = 0){
		if(damageCD < Time.time){
			Creature playerScript = player.GetComponent<Creature>();
			playerScript.TakeDamage(damage);
			if(isKnockBacking){
				float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);
				playerScript.KnockBack(new Vector2(Mathf.Cos(angle) * -knockBackForce, Mathf.Sin(angle) * -knockBackForce));
			}
			damageCD = Time.time + 0.25f;
		}
	}
	
	protected void reflectProjectile(GameObject projectile, Vector2 knockBack){
		Projectile projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.KnockBack(knockBack);
	}

	protected void Slow(GameObject target, float duration, float amount){
		Creature enemy = target.GetComponent<Creature>();
		enemy.Slow(duration, amount);
	}
}
