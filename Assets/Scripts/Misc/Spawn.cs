using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject Spawning;
	public Transform SpawnPos;

	// Use this for initialization
	void Start () {
		GameObject Start = Instantiate(Spawning, SpawnPos.position, SpawnPos.rotation) as GameObject; // Spawns the Char select
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
