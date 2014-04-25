using UnityEngine;
using System.Collections;

public class BigYoScript : MonoBehaviour {
	
	GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		transform.position = new Vector3(transform.position.x, transform.position.y, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(!player){
			Debug.LogWarning("Couldn't find a player, trying again!");
			player = GameObject.FindWithTag("Player");
		}
		else{
			//transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
			//transform.localRotation = player.transform.localRotation;
		}
	}
}
