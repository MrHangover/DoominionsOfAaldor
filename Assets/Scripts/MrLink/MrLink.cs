using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MrLink : Player {
	
	List<GameObject> teleYos = new List<GameObject>();
	int defStacks = 5;
	Animator yoAnimator;
	Animator linkAnimator;
	Animator[] animators;
	public GameObject ultYo;
	public GameObject teleYo;
	public GameObject defYo;
	float ultActiveTime = -1f;
	float defStackTime = 0f;

	// Use this for initialization
	void Start () {
		maxSpeed = 15f;
		maxHealth = 60;
		health = 60;
		animators = GetComponentsInChildren<Animator>();
		yoAnimator = animators[1];
		linkAnimator = animators[0];
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
			maxSpeed = Mathf.Lerp(0f, 50f, (15f - (ultActiveTime - Time.time))/15f);
		}

		if(maxSpeed > 15f){
			if(ultActiveTime < Time.time){
				maxSpeed = 15f;
				linkAnimator.SetBool("isUlting", false);
			}
		}

		if(defStackTime <= Time.time && defStacks < 5){
			defStacks++;
			defStackTime = Time.time + 20f;
		}

		if(immunityCD > Time.time)
			linkAnimator.SetBool("isDamaged", true);
		else
			linkAnimator.SetBool("isDamaged", false);


		// UI stuff

		if(offensiveCD > Time.time)
		{
			UIOffensiveCD = true;
		} else {
			UIOffensiveCD = false;
		}
		
		if(defensiveCD > Time.time)
		{
			UIDefensiveCD = true;
		} else {
			UIDefensiveCD = false;
		}
		
		if(movementCD > Time.time)
		{
			UIMovementCD = true;
		} else {
			UIMovementCD = false;
		}
		
		if(ultCD > Time.time)
		{
			UIUltCD = true;
		} else {
			UIUltCD = false;
		}

		// UI stuff end
	}

	protected override void NormalAttack(){
		if(normalCD <= Time.time){
			yoAnimator.SetTrigger("attack");
			normalCD = Time.time + 0.5f;
		}
	}

	protected override void OffensiveAbility(){
		if(offensiveCD <= Time.time){
			offensiveCD = Time.time + 4f;	
			GameObject tele = Instantiate(teleYo, 
			                              transform.position + new Vector3(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), 0f) * 1.2f,
			                              transform.rotation) as GameObject;
			tele.rigidbody2D.AddForce(new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 400f
			                          + rigidbody2D.velocity * 20f);
			tele.rigidbody2D.AddTorque(10f);
			teleYos.Add(tele);
			if(teleYos.Count > 5)
				teleYos.RemoveAt(0);
		}
	}
	
	protected override void DefensiveAbility(){
		if(defStacks > 0 && defensiveCD < Time.time){
			defensiveCD = Time.time + 0.5f;
			GameObject def = Instantiate(defYo, transform.position + new Vector3(0f, 2f, 0f), transform.rotation) as GameObject;
			defStacks--;
			Destroy(def, 10f);
		}
	}
	
	protected override void MovementAbility(){
		if(movementCD <= Time.time){
			movementCD = Time.time + 1f;
			GameObject telePos = null;
			foreach(GameObject o in teleYos)
				telePos = o;
			if(telePos){
				transform.position = telePos.transform.position;
				teleYos.Remove(telePos);
				Destroy(telePos);
			}
		}
	}
	
	protected override void UltAbility(){
		if(ultCD <= Time.time){
			Stun(1f);
			rigidbody2D.velocity = Vector2.zero;
			ultCD = 90f + Time.time;
			ultActiveTime = 16f + Time.time;
			immunityCD = 16f + Time.time;
			knockBackCD = 16f + Time.time;
			linkAnimator.SetBool("isUlting", true);
			linkAnimator.SetTrigger("ult");
			GameObject bigYo = Instantiate(ultYo, transform.position, transform.rotation) as GameObject;
			bigYo.transform.parent = transform;
			Destroy(bigYo, 16f);
		}
	}
}
