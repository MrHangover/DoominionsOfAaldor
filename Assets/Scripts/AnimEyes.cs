using UnityEngine;
using System.Collections;

public class AnimEyes : MonoBehaviour {
	
	public Animator animEyes;
	
	// Use this for initialization
	void Start () {
		
		animEyes = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		
		animEyes.SetFloat("vSpeed", Mathf.Abs(moveV));
		animEyes.SetFloat("hSpeed", Mathf.Abs(moveH));



		if(moveH < 0.1f || moveH > -0.1f)
		{
			transform.localPosition = new Vector3(0, (1f/10f) + (1f), 0);
		}

		if(moveH > 0.1f || moveH < -0.1f)
		{
			transform.localPosition = new Vector3(1f - (2f/3f), (1f/10f) + (1f), 0);
		}
	}
	
}