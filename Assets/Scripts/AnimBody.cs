using UnityEngine;
using System.Collections;

public class AnimBody : MonoBehaviour {

	public Animator animBody;

	// Use this for initialization
	void Start () {
	
		animBody = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		animBody.SetFloat("vSpeed", Mathf.Abs(moveV));
		animBody.SetFloat("hSpeed", Mathf.Abs(moveH));
	}
	
}
