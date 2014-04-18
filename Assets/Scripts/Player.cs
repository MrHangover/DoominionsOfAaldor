using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {

	protected float maxSpeed;
	public static bool facingRight = true;
	bool canMove = true;
	float moveTimer = 0.3f;
	protected int health = 100;
	public bool Speech;
	protected float moveH;
	protected float moveV;
	// Use this for initialization
	void Start () 
	{
		Speech = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");


		if(canMove){
				rigidbody2D.velocity = new Vector2(moveV * maxSpeed, rigidbody2D.velocity.y);
				rigidbody2D.velocity = new Vector2(moveH * maxSpeed, rigidbody2D.velocity.x);
		}

		if(Speech)
		{
			rigidbody2D.velocity = new Vector2 (0,0);
		}

		if(moveH != 0 || moveV != 0){
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(moveV, moveH) * (180f / Mathf.PI));
		}
	}

	void Update ()
	{

	}

	void OnCollisionEnter2D(Collision2D other){

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

	protected abstract void OffensiveAbility();

	protected abstract void DefensiveAbility();

	protected abstract void MovementAbility();

	protected abstract void UltAbility();

	public void Speechset() {
		Speech = true;
	}
}
