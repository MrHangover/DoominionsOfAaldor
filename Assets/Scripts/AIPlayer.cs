using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {

	public Transform Player;
	public Transform PlayerAI;
	
	float Movement = 10f;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		PlayerAI.position = Vector3.MoveTowards(transform.position, Player.position, Movement*Time.deltaTime);
		//Movement = 10f;
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{

				Movement = 0f;
				
		}

		if(other.gameObject.name == "AI-Player")
		{
			
			Movement = 0f;
			
		}

		if(other.gameObject.name == "AI-Player2")
		{
			
			Movement = 0f;
			
		}
	}
	

	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			Movement = 10f;
			
		}

		if(other.gameObject.name == "AI-Player")
		{
			
			Movement = 10f;
			
		}
		
		if(other.gameObject.name == "AI-Player2")
		{
			
			Movement = 10f;
			
		}

	}
	
}
