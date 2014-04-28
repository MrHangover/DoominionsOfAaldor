using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {

	public GameObject Player;
	public Transform SpawnPos;
	public GameObject SelectObejct;

	GameObject Interface;


	// Use this for initialization
	void Start () {

		Interface = GameObject.FindWithTag("UI");

		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseUp(){
		UI Begin = Interface.GetComponent<UI>();

		GameObject Spawn = Instantiate(Player, SpawnPos.position, SpawnPos.rotation) as GameObject;
		GameObject.Destroy (SelectObejct);
		Begin.Begin = true;
		Time.timeScale = 1f;
	}
}
