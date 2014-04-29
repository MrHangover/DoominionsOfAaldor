using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	// Declaration of the variables.

	public GameObject Player;
	public Transform SpawnPos;
	public GameObject SelectObejct;

	GameObject Interface;


	// Use this for initialization
	void Start () {

		Interface = GameObject.FindWithTag("UI");

		Time.timeScale = 0f;								// Sets the time gained every second by nothing
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseUp(){
		UI Begin = Interface.GetComponent<UI>();

		GameObject Spawn = Instantiate(Player, SpawnPos.position, SpawnPos.rotation) as GameObject;
		GameObject.Destroy (SelectObejct);		
		Begin.Begin = true;							// sends a bool to another script
		Time.timeScale = 1f;						// changes the time gained back to normal
		Screen.showCursor = false;					// hides the mouse
		Screen.lockCursor = true;					// locks the mouse
	}
}
