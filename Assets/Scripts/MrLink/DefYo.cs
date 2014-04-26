using UnityEngine;
using System.Collections;

public class DefYo : MonoBehaviour {

	float rot = 0f;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.transform.position + new Vector3(Mathf.Cos(rot), Mathf.Sin(rot), 0f) * 2f;
		rot += Time.deltaTime * 5f;
	}
}
