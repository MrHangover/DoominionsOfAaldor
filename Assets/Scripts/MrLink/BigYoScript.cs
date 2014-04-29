using UnityEngine;
using System.Collections;

public class BigYoScript : Weapon {
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y, 1);
	}

	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			dealDamage(other.gameObject, 10, true, 30);
		}
		else if (other.gameObject.tag == "EnemyProjectile"){
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			reflectProjectile(other.gameObject, new Vector2(Mathf.Cos(angle) * -50f, Mathf.Sin(angle) * -50f));
		}
	}
}
