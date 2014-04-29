using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

		GameObject.DestroyObject(gameObject,5);
		Screen.lockCursor = false;
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
