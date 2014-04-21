using UnityEngine;
using System.Collections;

public class AttackBall : MonoBehaviour {

	public GameObject PlayerP;
	Animator ABall;
	Vector2 vel;


	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);
		ABall = GetComponent<Animator>();
		ABall.SetBool("Bounce", true);



	

		rigidbody2D.velocity = vel*10;

	}
	
	// Update is called once per frame
	void Update () {


			
	}
}

