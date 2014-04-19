using UnityEngine;
using System.Collections;

public class MrLink : Player {
	
	Animator animator;

	// Use this for initialization
	void Start () {
		maxSpeed = 15f;
		maxHealth = 60;
		health = 60;
		animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void NormalAttack(){
		if(normalCD <= Time.time){
			animator.SetTrigger("attack");
			normalCD = Time.time + 1f;
			Debug.Log("LOL");
		}
	}

	protected override void OffensiveAbility(){
		
	}
	
	protected override void DefensiveAbility(){
		
	}
	
	protected override void MovementAbility(){
		
	}
	
	protected override void UltAbility(){
		
	}
}
