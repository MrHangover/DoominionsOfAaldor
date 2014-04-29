using UnityEngine;
using System.Collections;

public class NovaShard : Projectile { //NovaSHard is a projectile
	

	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,2.5f);
		//the projectile is destroyed 2.5 seconds after spawn

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 15); //It rotates at a speed of 15
	}
	
	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 0, true, 25);
			Slow(other.gameObject,1.5f, 0.9f);
			Slow(other.gameObject,3f, 0.5f);
			Slow(other.gameObject,4.5f, 0.25f);
	}

	//As the Novashard is a projectile, it needs additional info:
	//It targets objects of type "Enemy"
	//It deals no damage, but has a high knockbackvalue of 25
	//It applies 3 slows to the enemy:
	//A strong, 90%, slow for 1.5 seconds
	//A slow of 50% for 3 seconds
	//And a weak slow of 25% for 4.5 seconds
	//All of them is applied simultanously
}
