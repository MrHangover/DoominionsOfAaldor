using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static public float maxSpeed = 5f;
	static public bool facingRight = true;
	public bool canMove = true;
	public bool Speech;
	static public float moveTimer = 0.3f;



	// Use this for initialization
	void Start () 
	{
		Speech = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

	



		if(!Speech)
		{


			float moveH = Input.GetAxis ("Horizontal");
			float moveV = Input.GetAxis ("Vertical");




			if(canMove){
					rigidbody2D.velocity = new Vector2(moveV * maxSpeed, rigidbody2D.velocity.y);
					rigidbody2D.velocity = new Vector2(moveH * maxSpeed, rigidbody2D.velocity.x);
			}

			if(moveH > 0 && !facingRight)
				Flip();
			else if(moveH < 0 && facingRight)
				Flip();

				
			if(canMove == false)
				moveTimer -= Time.deltaTime;
			if(moveTimer < 0f){
				canMove = true;
				moveTimer = 0.3f;
				}
		}

		if(Speech)
		{
			rigidbody2D.velocity = new Vector2 (0,0);

		}

		
	}

	void Update ()
	{

	}

	void OnCollisionEnter2D(Collision2D other){
		canMove = false;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void Speechset() {
		Speech = true;
	}
}
