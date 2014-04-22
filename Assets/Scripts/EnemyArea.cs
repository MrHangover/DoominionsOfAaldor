using UnityEngine;
using System.Collections;

public class EnemyArea : MonoBehaviour {

	public GameObject AttackPoint;
	public Transform Enemy;
	
	float Movement = 8f;

	bool Combat = false;

	// Use this for initialization
	void Start () {
		AttackPoint = GameObject.FindWithTag("Player");
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
				Enemy.position = Vector3.MoveTowards(transform.position, AttackPoint.transform.position , Movement*Time.deltaTime);
				Debug.Log("Test");
				
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
