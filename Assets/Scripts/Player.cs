using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {

	public static bool facingRight = true;
	public bool Speech;
	protected float moveH;
	protected float moveV;
	protected float maxSpeed;
	protected int health;
	protected int maxHealth;
	protected float normalCD = 0f;
	protected float offensiveCD = 0f;
	protected float speedCD = 0f;
	protected float defensiveCD = 0f;
	protected float ultCD;
	bool canMove = true;
	float moveTimer = 0.3f;

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
			transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(moveV, moveH) * (180f / Mathf.PI) - 90);
			if(transform.eulerAngles.z < 360)
				transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 360);
		}
	}

	void Update ()
	{
		if(Input.GetButton("Normal"))
			NormalAttack();
		if(Input.GetButton("Offensive"))
			OffensiveAbility();
		if(Input.GetButton("Defensive"))
			DefensiveAbility();
		if(Input.GetButton("Speed"))
			MovementAbility();
		if(Input.GetButton("Ult"))
			UltAbility();
	}

	void OnCollisionEnter2D(Collision2D other){

	}

	public void TakeDamage(int damage){
		health -= damage;
		if(health > maxHealth)
			health = maxHealth;
	}

	public void KnockBack(Vector2 direction, float force){

	}

	public void Stun(float duration){

	}

	protected abstract void NormalAttack();

	protected abstract void OffensiveAbility();

	protected abstract void DefensiveAbility();

	protected abstract void MovementAbility();

	protected abstract void UltAbility();

	public void Speechset() {
		Speech = true;
	}
}
