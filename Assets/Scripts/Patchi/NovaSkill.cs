using UnityEngine;
using System.Collections;

public class NovaSkill : Weapon {

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,1);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, -0.5f);
		transform.localScale += new Vector3 ((0f + 1f/6f),(0f + 1f/6f),0f);

	}

	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 100, false, 0);
	}


}
