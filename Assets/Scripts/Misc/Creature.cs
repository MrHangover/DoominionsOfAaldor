using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {
	
	protected float maxSpeed;
	protected int health;
	protected int maxHealth;
	protected bool canMove = true;
	protected float stunnedCD = 0f;
	protected float immunityCD = 0f;
	protected float knockBackCD = 0f;
	
	public void TakeDamage(int damage){
		if(immunityCD < Time.time){
			health -= damage;
			if(health > maxHealth)
				health = maxHealth;
			if(health < 1)
				Destroy(gameObject);
			immunityCD = Time.time + 0.25f;
		}
	 }
	
	public void KnockBack(Vector2 force){
		if(knockBackCD < Time.time){
			Stun (0.25f);
			rigidbody2D.velocity = force;
			immunityCD = Time.time + 0.5f;
			knockBackCD = Time.time + 0.5f;
		}
	}
	
	public void Stun(float duration){
		canMove = false;
		stunnedCD = duration + Time.time;
	}
}
