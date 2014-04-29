/// <summary>
/// Archer shot.
/// This is the script for controlling the projectiles from the Archer. It'll deal damage to players.
/// It extends from the Projectile class, as it can collide with objects.
/// </summary>

using UnityEngine;
using System.Collections;

public class ArcherShot : Projectile {								

	void Start () {
		Destroy(gameObject, 5);										//Destroys the projectile after 5 seconds.
	}
	
	protected override void OnCollisionEnter2D(Collision2D other){	//Called whenever the projectile collides with something.
		if(other.gameObject.tag == "Player"){						//If it collides with a player, deal damage to it.
			dealDamage(other.gameObject, 6, false);
		}
		Destroy(gameObject);										//Destroy the projectile whenever it collides with something.
	}
}
