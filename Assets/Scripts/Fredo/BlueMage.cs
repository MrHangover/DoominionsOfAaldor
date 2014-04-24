using UnityEngine;
using System.Collections;

public class BlueMage : Player {

	Animator blueAnimator;
	Animator[] animators;
	BoxCollider2D boxCollider2D;
	public GameObject ultBlue;
	float ultActiveTime = -1f;
	
	// Use this for initialization
	void Start () {
		maxSpeed = 15f;
		maxHealth = 60;
		health = 60;
		animators = GetComponentsInChildren<Animator>();
		blueAnimator = animators[0];
	}
	
	// Update is called once per frame
	void Update () {
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
		
		if(ultActiveTime >= Time.time){
			maxSpeed = Mathf.Lerp(0f, 30f, (15f - (ultActiveTime - Time.time))/15f);
		}
		if(maxSpeed > 15f){
			if(ultActiveTime < Time.time){
				maxSpeed = 15f;

			}
		}
	}
	
	protected override void NormalAttack(){
		if(normalCD <= Time.time){
			normalCD = Time.time + 0.5f;
		}
	}
	
	protected override void OffensiveAbility(){
		if(offensiveCD <= Time.time){
			
		}
	}
	
	protected override void DefensiveAbility(){
		if(defensiveCD <= Time.time){
			
		}
	}
	
	protected override void MovementAbility(){
		if(movementCD <= Time.time){
			
		}
	}
	
	protected override void UltAbility(){
		if(ultCD <= Time.time){
			Stun(1f);
			rigidbody2D.velocity = Vector2.zero;
			ultActiveTime = 16f + Time.time;

		}
	}
}