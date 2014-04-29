/// <summary>
/// Slinger shot.
/// Script for controlling the projectile being shot from the Slinger enemy.
/// It extends from the Projectile class as it can collide with objects.
/// </summary>

using UnityEngine;
using System.Collections;

public class SlingerShot : Projectile {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);								//Destroy the projectile after 5 seconds.
	}

	protected override void OnCollisionEnter2D(Collision2D other){	//Called whenever the projectile collides with something.
		if(other.gameObject.tag == "Player"){						//If it collides with a player, deal damage to it.
			dealDamage(other.gameObject, 6, false);
		}
		Destroy(gameObject);									//Destroy the projectile whenever it collides with something.
	}
}
