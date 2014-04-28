using UnityEngine;
using System.Collections;

public class AttackCakeSkill : Projectile {

	public GameObject PlayerP;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);


		Player script = PlayerP.GetComponent<Player>();
		

	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, -3.0f);

	
	
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 10, true, 5);
	}

	protected override void OnTriggerEnter2D(Collider2D other){
		
	}
}
