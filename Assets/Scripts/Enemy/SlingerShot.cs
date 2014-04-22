using UnityEngine;
using System.Collections;

public class SlingerShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.rigidbody2D.velocity += this.rigidbody2D.velocity;
		}
		if(other.gameObject.tag != "Enemy")
			Destroy(this.gameObject);
	}
}
