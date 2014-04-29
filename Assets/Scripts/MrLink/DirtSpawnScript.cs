/// <summary>
/// Dirt spawn script.
/// This script is used for spawning dirt particles behind the big yoyo which is spawned whenever the MrLink character uses
/// his ult ability. It spawns dirt particles, and sends them flying in a direction based on the big yoyo's velocity and rotation.
/// </summary>

using UnityEngine;
using System.Collections;

public class DirtSpawnScript : MonoBehaviour {

	public GameObject Dirt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject dirt = Instantiate(Dirt, transform.position + new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(-0.9f, 0.9f), 0), transform.rotation) as GameObject;

		dirt.rigidbody2D.AddForce(transform.parent.transform.parent.rigidbody2D.velocity * 8f + 
		                          new Vector2(Mathf.Cos((transform.eulerAngles.z - 90f) * (Mathf.PI / 180f)), Mathf.Sin((transform.eulerAngles.z - 90f) * (Mathf.PI / 180f))) * 100f);

		Destroy (dirt, 1f);
	}
}
