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
