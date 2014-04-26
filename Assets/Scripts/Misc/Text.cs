using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	GameObject ActivePlayer;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		ActivePlayer = GameObject.FindWithTag("Player");
		Player Talk = ActivePlayer.GetComponent<Player>();

		if(other.gameObject.tag == "Player")
		{
			Talk.Speechset();


		
		}
	}

}
