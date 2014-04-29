//<summary>
//This is the script for the defensive yoyo, spawned when the MrLink character uses its defensive ability.
//The yoyo will rotate around the player, deal damage and knock back enemies, and reflect any enemy projectiles.
//The yoyo doesn't technically collide with anything, as it is a trigger. It extends from the Weapon class.
//</summary>

using UnityEngine;
using System.Collections;

public class DefYo : Weapon {

	float rot = 0f;									//Start the rotation at 0
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");	//Find the player.
	}
	
	// Update is called once per frame
	void FixedUpdate () {																						
		transform.position = player.transform.position + new Vector3(Mathf.Cos(rot), Mathf.Sin(rot), 0f) * 2f;	//Change the yoyo's position based on the players position and the
		rot += Time.deltaTime * 20f;																			//"rot" variable. Then increase the rot variable.
	}

	protected override void OnTriggerEnter2D(Collider2D other){	//Called whenever the yoyo "collides" with something.
		if(other.gameObject.tag == "EnemyProjectile"){			//If it collided with an enemy projectile, knock it away from itself.
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			reflectProjectile(other.gameObject, new Vector2(Mathf.Cos(angle) * -30f, Mathf.Sin(angle) * -30f));
		}
		if(other.gameObject.tag == "Enemy"){					//If it collided with an enemy, deal damage to it and knock it back.
			dealDamage(other.gameObject, 5, true, 20);
		}
	}
}
