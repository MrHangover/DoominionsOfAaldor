using UnityEngine;
using System.Collections;

public class IceShard3 : MonoBehaviour {
	
	public GameObject PlayerF;
	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,3);
		
		
		Player script = PlayerF.GetComponent<Player>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 0);
		
		
		
	}
}
