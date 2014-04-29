using UnityEngine;
using System.Collections;

public class IceParticle : MonoBehaviour { //IceParticle is a MonoBehaviour
	

	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.3f);
		//The particles will despawn after 0.3 seconds

		

		
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.Rotate(0, 0, 10);
		// The particles rotates
		
		
		
	}
}
