using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	



	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

	


	


	


		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");





		rigidbody2D.velocity = new Vector2(moveV * maxSpeed, rigidbody2D.velocity.y);

		rigidbody2D.velocity = new Vector2(moveH * maxSpeed, rigidbody2D.velocity.x);

		if(moveH > 0 && !facingRight)
			Flip();
		else if(moveH < 0 && facingRight)
			Flip();


	}

	void Update ()
	{

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
