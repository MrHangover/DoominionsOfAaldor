//<Summary>
//This is a script for controlling the camera. It makes sure that the camera is always
//centered on a player.
//</Summary>

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");						//Try to find the player.
	}
	
	// Update is called once per frame
	void Update () {
		if(!player){													//If no player was found,
			Debug.LogWarning("Couldn't find a player, trying again!");	//send a warning to the console,
			player = GameObject.FindWithTag("Player");					//then try to find a player again.
		}																//
		else 															//If a player was found, center the camera on the player.
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}
}
