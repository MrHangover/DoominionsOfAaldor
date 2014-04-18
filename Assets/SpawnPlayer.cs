using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public GameObject PlayerP;
	public Transform SpawnPos;
	private Player test;

	// Use this for initialization
	void Start () {
		GameObject Spawn = Instantiate(PlayerP, SpawnPos.position, SpawnPos.rotation) as GameObject;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
