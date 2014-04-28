using UnityEngine;
using System.Collections;

public class NovaShard : Projectile {
	

	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3.5f);
		

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 15);
	}
	
	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 0, true, 25);
			Slow(other.gameObject,1.5f, 0.9f);
			Slow(other.gameObject,3f, 0.5f);
			Slow(other.gameObject,4.5f, 0.25f);
	}
}
