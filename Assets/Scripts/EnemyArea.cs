using UnityEngine;
using System.Collections;

public class EnemyArea : MonoBehaviour {

	public Transform Player;
	public Transform Enemy;
	
	float Movement = 8f;

	bool Combat = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerStay2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{

			if(Combat == false)
			{
				Enemy.position = Vector3.MoveTowards(transform.position, Player.position, Movement*Time.deltaTime);
				
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Combat = true;
			
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Combat = false;
			
		}
	}
}
