﻿using UnityEngine;
using System.Collections;

public class NovaSkill : Weapon {

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,1); 								// The object gets destoryed after 1f
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, -0.5f);											// Rotates the object
		transform.localScale += new Vector3 ((0f + 1f/6f),(0f + 1f/6f),0f);		// Increase the scale of the object
	}

	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 100, false, 0);						// Deals damage to enemys being hit
	}
}
