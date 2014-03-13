using UnityEngine;
using System.Collections;

public class AnimMouth : MonoBehaviour {
	
	public Animator animMouth;
	
	// Use this for initialization
	void Start () {
		
		animMouth = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		
		animMouth.SetFloat("vSpeed", Mathf.Abs(moveV));
		animMouth.SetFloat("hSpeed", Mathf.Abs(moveH));

		if(moveH < 0.1f || moveH > -0.1f)
		{
			transform.localPosition = new Vector3(0, 1f - (3f/10f), 0);
		}
		
		if(moveH > 0.1f || moveH < -0.1f)
		{
			transform.localPosition = new Vector3(1f - (2f/3f), 1f - (3f/10f), 0);
		}
	}
	
}