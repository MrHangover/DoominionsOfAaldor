using UnityEngine;
using System.Collections;

public class AttackCakeSkill : MonoBehaviour {

	public GameObject PlayerP;

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);


		Player script = PlayerP.GetComponent<Player>();
		
		/*if(Player.facingRight == true)
		{
			rigidbody2D.velocity = new Vector2(20,0);
		}
		
		if(Player.facingRight == false)
		{
			rigidbody2D.velocity = new Vector2(20*-1,0);
		}*/
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, -3.0f);

	
	
	}
}
