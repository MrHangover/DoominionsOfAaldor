using UnityEngine;
using System.Collections;

public class AttackBall : MonoBehaviour {

	public GameObject Player;
	Animator ABall;

	float BounceCD = 0f;
	float BounceReturnCD = 0f;

	bool UP = false;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);
		ABall = GetComponent<Animator>();
		ABall.SetBool("Bounce", true);
		Bounce();



		if(PlayerController.facingRight == true)
		{
			rigidbody2D.velocity = new Vector2(10,-5);
		
		}

		
		if(PlayerController.facingRight == false)
		{
			rigidbody2D.velocity = new Vector2(10*-1,-5);
		}

	}
	
	// Update is called once per frame
	void Update () {

		PlayerController script = Player.GetComponent<Player>();


			
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
