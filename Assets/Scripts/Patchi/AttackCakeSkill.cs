using UnityEngine;
using System.Collections;

public class AttackCakeSkill : Projectile {

	public GameObject PlayerP;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3); // The object gets destoryed after 3f
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, -3.0f); // rotates the object
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 10, true, 5); 	// if the enemy gets hit by this object it will take dmg and get some knockback
	}
}
