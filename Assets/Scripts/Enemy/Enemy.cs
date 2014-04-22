using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	bool canMove = true;

	protected float maxSpeed;
	protected int health;
	protected int maxHealth;

	float stunnedCD = -1f;


	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate ()
	{

		if(canMove){






			if(!canMove && stunnedCD < Time.time)
				canMove = true;
		}

	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage){
		health -= damage;
		if(health > maxHealth)
			health = maxHealth;
	}

	public void Stun(float duration){
		canMove = false;
		stunnedCD = duration + Time.time;
	}
}
