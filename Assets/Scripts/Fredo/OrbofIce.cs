using UnityEngine;
using System.Collections;

public class OrbofIce : MonoBehaviour {
	
	public GameObject PlayerF; //Change to F
	// Use this for initialization
	public GameObject AttackIce1;
	public Transform AttackIcePos1;
	
	public GameObject AttackIce2;
	public Transform AttackIcePos2;
	
	public GameObject AttackIce3;
	public Transform AttackIcePos3;
	
	public GameObject AttackIce4;
	public Transform AttackIcePos4;
	
	private void Orb(){
		GameObject IceShard = Instantiate(AttackIce1, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
		IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
		
		GameObject IceShard2 = Instantiate(AttackIce2, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
		IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
		
		GameObject IceShard3 = Instantiate(AttackIce3, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
		IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
		
		GameObject IceShard4 = Instantiate(AttackIce4, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
		IceShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
	}
	
	void Start () {
		GameObject.DestroyObject(gameObject,5);
		
		InvokeRepeating ("Orb", 0.2f, 0.1f);
		
		Player script = PlayerF.GetComponent<Player>();
		
	}
	// Update is called once per frame
	void Update () {
		
		
		
		transform.Rotate (0,0,-5.0f);
	}
	// Rotates the Orb
}
