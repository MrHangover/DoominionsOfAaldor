using UnityEngine;
using System.Collections;

public class SlingerShot : Projectile {

	// Use this for initialization
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
