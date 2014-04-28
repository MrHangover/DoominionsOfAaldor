﻿using UnityEngine;
using System.Collections;

public class OrbShard : Projectile {
	
	public GameObject PlayerF;
	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.45f);
		
		
		Player script = PlayerF.GetComponent<Player>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 0);	
	}
	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 1, false);
	}
}
