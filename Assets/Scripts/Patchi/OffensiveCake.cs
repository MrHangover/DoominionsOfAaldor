using UnityEngine;
using System.Collections;

public class OffensiveCake : MonoBehaviour {

	public GameObject PlayerP;
	Animator ABall;
	Vector2 vel;

	float TimeCake = -1f;


	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);
		ABall = GetComponent<Animator>();
		ABall.SetBool("Bounce", true);

		TimeCake = 2f + Time.time;

	

		rigidbody2D.velocity = vel*10;

	}
	
	// Update is called once per frame
	void Update () {

		if(TimeCake < Time.time)
		{


		}

			
	}
}

