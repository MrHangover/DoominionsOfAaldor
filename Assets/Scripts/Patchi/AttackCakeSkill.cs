using UnityEngine;
using System.Collections;

public class AttackCakeSkill : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);


		PlayerController script = Player.GetComponent<PlayerController>();
		
		if(PlayerController.facingRight == true)
		{
			rigidbody2D.velocity = new Vector2(20,0);
		}
		
		if(PlayerController.facingRight == false)
		{
			rigidbody2D.velocity = new Vector2(20*-1,0);
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, -3.0f);

	
	
	}
}
