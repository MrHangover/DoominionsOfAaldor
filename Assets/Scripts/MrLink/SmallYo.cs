/// <summary>
/// Small yo.
/// This is the script for the MrLink characters normal attack ability. Note that the MrLink.cs script controls the movement of
/// the yoyo, this script only takes care of collisions. Whenever the small yoyo hits an enemy, deal damage to it and knock it back.
/// If it collides with an enemy projectile, knock that projectile away. It extends from the Weapon class as it technically doesn't
/// collide with anything since its collider is a trigger.
/// </summary>

using UnityEngine;
using System.Collections;

public class SmallYo : Weapon {

	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 10, true, 10);
		else if(other.gameObject.tag == "EnemyProjectile"){
			float angle = Mathf.Atan2(transform.parent.transform.position.y - other.transform.position.y, transform.parent.transform.position.x - other.transform.position.x);
			reflectProjectile(other.gameObject, new Vector2(Mathf.Cos(angle) * -20f, Mathf.Sin(angle) * -20f));
		}
	}
}
