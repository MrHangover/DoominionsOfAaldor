using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {

	float maxSpeed;
	bool facingRight = true;
	bool canMove = true;
	float moveTimer = 0.3f;
	int health = 100;
	public bool Speech;

	Player(float mSpeed, int hp){
		health = hp;
	}

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
		}

		if(canMove){
				rigidbody2D.velocity = new Vector2(moveV * maxSpeed, rigidbody2D.velocity.y);
				rigidbody2D.velocity = new Vector2(moveH * maxSpeed, rigidbody2D.velocity.x);
		}

		if(Speech)
		{
			rigidbody2D.velocity = new Vector2 (0,0);
		}

		if(moveH > 0 && !facingRight)
			Flip();
		else if(moveH < 0 && facingRight)
			Flip();
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

	public void TakeDamage(int damage){
		health -= damage;
	}

	public void KnockBack(Vector2 direction, float force){

	}

	public void Stun(float duration){

	}

	void OffensiveAbility(){

	}

	void DefensiveAbility(){

	}

	void MovementAbility(){

	}

	void UltAbility(){

	}

	public void Speechset() {
		Speech = true;
	}
}
