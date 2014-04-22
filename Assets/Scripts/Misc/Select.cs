using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public GameObject Player;
	public Transform SpawnPos;
	public GameObject SelectObejct;
	


	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseUp(){

			GameObject Spawn = Instantiate(Player, SpawnPos.position, SpawnPos.rotation) as GameObject;
			GameObject.Destroy (SelectObejct);
			Time.timeScale = 1f;

	
	}
}
