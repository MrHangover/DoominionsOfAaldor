using UnityEngine;
using System.Collections;

public class AnimLowBody : MonoBehaviour {
	
	public Animator animLowBody;
	
	// Use this for initialization
	void Start () {
		
		animLowBody = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		
		animLowBody.SetFloat("vSpeed", Mathf.Abs(moveV));
		animLowBody.SetFloat("hSpeed", Mathf.Abs(moveH));

		if(moveH < 0.1f || moveH > -0.1f)
		{
			transform.localPosition = new Vector3(0f,-1f, 2f);
		}
		
		if(moveH > 0.1f || moveH < -0.1f)
		{
			transform.localPosition = new Vector3(0f + (1f/20f),-1f, 2f);
		}
	}
	
}