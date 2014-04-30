using UnityEngine;
using System.Collections;

public class Lost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Normal"))
			Application.LoadLevel(0);

	}
}
