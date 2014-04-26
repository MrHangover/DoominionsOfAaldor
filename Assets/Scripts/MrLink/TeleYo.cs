using UnityEngine;
using System.Collections;

public class TeleYo : MonoBehaviour {

	CircleCollider2D circleCollider;
	float time;

	// Use this for initialization
	void Start () {
		circleCollider = GetComponent<CircleCollider2D>();
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(rigidbody2D.velocity.x + rigidbody2D.velocity.y) < 0.5f)
			circleCollider.enabled = false;
		else
			circleCollider.enabled = true;

		if(Time.time > time + 20f)
			Destroy(gameObject);
	}
}
