using UnityEngine;
using System.Collections;

public class IceShard: Projectile { //IceShard is a Projectile
	

	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,2.5f);
		// The projectile is destroyed 2.5 seconds after spawn
		
	
		

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 0); // it does not rotate
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 4, true, 2);
			Slow(other.gameObject,3f, 0.45f);
	}
	//As the iceshard is a projectile, it needs additional info:
	//It targets objects of type "Enemy"
	//It deals 4 points of damage, and has a knockbackvalue of 2
	//It slows the enemy for 45% for 3 seconds
}
