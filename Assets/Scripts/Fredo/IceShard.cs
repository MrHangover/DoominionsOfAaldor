using UnityEngine;
using System.Collections;

public class IceShard : MonoBehaviour {

	public GameObject PlayerF; //Change to F
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject (gameObject,3);

		Player script = PlayerF.GetComponent<Player>(); //Change to PlayerF
		
		if(Player.facingRight==true){
			rigidbody2D.velocity = new Vector2(20,0);
		}
		/*if(Player.facingLeft==true){
			rigidbody2D.velocity = new Vector2(20*-1,0);
		}
		/*	if (Player.facingUp==true){
		 	rigidbody2d.velocity = newVector2(0,20);
		}

		 if(Player.facingDown=true){
			rigidbody2d.velocity = newVector2(0,20*-1);
		}*/ //Searches for the player character's facing, before firing the Shard (the vector of the Orb is determined)
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
