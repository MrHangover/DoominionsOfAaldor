/// <summary>
/// Tele yo.
/// This is the script for controlling the yoyo that is shot from the MrLink character when it uses its offensive ability.
/// It extends from the Projectile class, as it is able to collide with other objects.
/// </summary>

using UnityEngine;
using System.Collections;

public class TeleYo : Projectile {

	CircleCollider2D circleCollider;
	float time;

	// Use this for initialization
	void Start () {
		circleCollider = GetComponent<CircleCollider2D>();						//Find the yoyo's collider
		time = Time.time;														//Get the current time.
	}

	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(rigidbody2D.velocity.x + rigidbody2D.velocity.y) < 0.5f)	//If the yoyo is almost lying still or lying still,
			circleCollider.enabled = false;										//disable its collider so it won't collide with objects,
		else 																	//otherwise let it collide with objects.
			circleCollider.enabled = true;

		if(Time.time > time + 20f)									//After 20 seconds, destoy this object.
			Destroy(gameObject);
	}

	protected override void OnCollisionEnter2D(Collision2D other){	//Called whenever the yoyo collides with something
		if(other.gameObject.tag == "Enemy")							//If it collides with an enemy, deal damage to it
			dealDamage(other.gameObject, 15, true, 12);				//and knock it back.
	}
}
