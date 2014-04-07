using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public GameObject Player;
	public Transform SpawnPos;
	private PlayerController test;

	// Use this for initialization
	void Start () {
		GameObject Spawn = Instantiate(Player, SpawnPos.position, SpawnPos.rotation) as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
