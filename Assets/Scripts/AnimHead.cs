using UnityEngine;
using System.Collections;

public class AnimHead : MonoBehaviour {
	
	public Animator animHead;
	
	// Use this for initialization
	void Start () {
		
		animHead = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		
		animHead.SetFloat("vSpeed", Mathf.Abs(moveV));
		animHead.SetFloat("hSpeed", Mathf.Abs(moveH));
	}
	
}