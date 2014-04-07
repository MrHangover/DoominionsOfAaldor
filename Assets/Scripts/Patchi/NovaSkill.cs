using UnityEngine;
using System.Collections;

public class NovaSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,1);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 0, -0.5f);
		transform.localScale += new Vector3 ((0f + 1f/6f),(0f + 1f/6f),0f);

	}
}
