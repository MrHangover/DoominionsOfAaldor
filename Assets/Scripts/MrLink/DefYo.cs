using UnityEngine;
using System.Collections;

public class DefYo : Weapon {

	float rot = 0f;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.transform.position + new Vector3(Mathf.Cos(rot), Mathf.Sin(rot), 0f) * 2f;
		rot += Time.deltaTime * 5f;
	}

	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "EnemyProjectile"){
			float angle = Mathf.Atan2(transform.position.y - other.transform.position.y, transform.position.x - other.transform.position.x);
			reflectProjectile(other.gameObject, new Vector2(Mathf.Cos(angle) * -30f, Mathf.Sin(angle) * -30f));
		}
		if(other.gameObject.tag == "Enemy"){
			dealDamage(other.gameObject, 2, true, 20);
		}
	}
}
