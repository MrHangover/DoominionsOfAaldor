//<Summary>
//This is the script controlling the big yoyo which is spawned when a player controlling the MrLink character uses
//the MrLink character's ult ability. The yoyo will deal damage and knock back enemies, and also knock back
//any enemy projectiles. Note that the yoyo has a trigger, so it technically doesn't collide with anything.
//The script extends from the Weapon class.
//</Summary>

using UnityEngine;
using System.Collections;

public class BigYoScript : Weapon {
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y, 1);//Makes sure that the yoyo is located below the player.
	}

	protected override void OnTriggerEnter2D(Collider2D other){							//This function is called whenever something enters the yoyo collision area.
		if(other.gameObject.tag == "Enemy"){											//If it "collides" with an enemy, deal damage to it, and knock it back.
			dealDamage(other.gameObject, 15, true, 30);
		}
		else if (other.gameObject.tag == "EnemyProjectile"){							//If it "collides" with an enemy projectile, reflect the projectile away from the yoyo.
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			reflectProjectile(other.gameObject, new Vector2(Mathf.Cos(angle) * -50f, Mathf.Sin(angle) * -50f));
		}
	}
}
