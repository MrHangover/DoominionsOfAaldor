using UnityEngine;
using System.Collections;

public class BlueMage : Player {

	Animator blueAnimator;
	Animator[] animators;
	BoxCollider2D boxCollider2D;
	public GameObject ultBlue;
	float ultActiveTime = -1f;
	float AttackIceCD = 0;


	public GameObject AttackIce;
	public Transform AttackIcePos;

	public GameObject AttackOrb;
	public Transform AttackOrbPos;


	// Use this for initialization
	void Start () {
		maxSpeed = 5f;
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
		if(maxSpeed > 5f){
			if(ultActiveTime < Time.time){
				maxSpeed = 5f;

			}
		}
	}
	void CDAttackIce () {
		normalCD = 0.5f + Time.time;
		
		return;
	}
	
	protected override void NormalAttack(){
		if(normalCD <= Time.time){
			GameObject IceShard = Instantiate(AttackIce, AttackIcePos.position, AttackIcePos.rotation) as GameObject;
			IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                        Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
			CDAttackIce();
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
			GameObject OrbofIce = Instantiate(AttackOrb, AttackOrbPos.position, AttackOrbPos.rotation) as GameObject;
			OrbofIce.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
			                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
			CDAttackIce();
			ultCD = Time.time + 8f;

		}
	}
}