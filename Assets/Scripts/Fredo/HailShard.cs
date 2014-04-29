using UnityEngine;
using System.Collections;

public class HailShard : Projectile { //HailShard is a Projectile

	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.3f);
		//The object is destroyed 0.3 seconds after it spawned
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 15); //it will rotate at 15 speed around the z axis
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 3, true, 5);
			Slow(other.gameObject,1.5f, 0.75f);
	} //As the hailshard is a projectile, it needs additional info:
	//It targets objects of type "Enemy"
	//It deals 3 points of damage, and has a knockbackvalue of 5
	//It slows the enemy for 75% for 1.5 seconds
	protected override void OnTriggerEnter2D(Collider2D other){
		
	}

}
