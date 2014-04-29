using UnityEngine;
using System.Collections;

public class ArcherShot : Projectile {

	void Start () {
		Destroy(this.gameObject, 5);
	}
	
	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			dealDamage(other.gameObject, 6, false);
		}
		Destroy(this.gameObject);
	}
}
