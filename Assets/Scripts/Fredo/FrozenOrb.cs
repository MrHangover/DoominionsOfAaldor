using UnityEngine;
using System.Collections;

public class FrozenOrb : MonoBehaviour {

	public GameObject PlayerF; //Change to F
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject (gameObject,3); //Despawns the Orb after 3 seconds
	
		Player script = PlayerF.GetComponent<Player>(); //Change to PlayerF

		if(Player.facingRight==true){
			rigidbody2D.velocity = newVector2(20,0);
		}
		if(Player.facingLeft==true){
			rigidbody2D.velocity = newVector2(20*-1,0);
		}
	/*	if (Player.facingUp==true){
		 	rigidbody2d.velocity = newVector2(0,20);
		}

		 if(Player.facingDown=true){
			rigidbody2d.velocity = newVector2(0,20*-1);
		}*/ //Searches for the player character's facing, before firing the Orb (the vector of the Orb is determined)
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,-5.0f);
	}
	// Rotates the Orb
}
