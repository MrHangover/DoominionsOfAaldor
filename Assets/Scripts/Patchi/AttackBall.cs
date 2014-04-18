using UnityEngine;
using System.Collections;

public class AttackBall : MonoBehaviour {

	public GameObject PlayerP;
	Animator ABall;
	Vector2 vel;
	float BounceCD = 0f;
	float BounceReturnCD = 0f;

	bool UP = false;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);
		ABall = GetComponent<Animator>();
		ABall.SetBool("Bounce", true);
		Bounce();



		/*if(Player.facingRight == true)
		{
			rigidbody2D.velocity = new Vector2(10,-5);
		
		}

		
		if(Player.facingRight == false)
		{
			rigidbody2D.velocity = new Vector2(10*-1,-5);
		}*/

		rigidbody2D.velocity = vel*10;

	}
	
	// Update is called once per frame
	void Update () {

		Player script = PlayerP.GetComponent<Player>();


			
			if(BounceReturnCD < Time.time)
			{
				if(UP == false)
				{
					rigidbody2D.velocity += new Vector2(0,10f);
					Bounce();
					UP = true;
				}
					

			}
			
			
			if(BounceCD < Time.time)
			{
				if(UP == true)
				{
					rigidbody2D.velocity += new Vector2(0,-10f);
					BounceReturn();
					UP = false;
				}

			}
	}


	void Bounce() {
		BounceCD = 0.5f + Time.time;
		
		return;
	}

	void BounceReturn() {
		BounceReturnCD = 0.5f + Time.time;
		
		return;
	}
}
