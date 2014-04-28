using UnityEngine;
using System.Collections;

public class OrbofIce : MonoBehaviour {
	
	public GameObject PlayerF; 
	// Use this for initialization

	public GameObject AttackIce;
	public Transform AttackIcePos1;
	public Transform AttackIcePos2;
	public Transform AttackIcePos3;
	public Transform AttackIcePos4;
	public Transform AttackIcePos5;
	public Transform AttackIcePos6;
	public Transform AttackIcePos7;
	public Transform AttackIcePos8;

	
	private void Orb1(){
			GameObject OrbShard = Instantiate (AttackIce, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb2(){
			GameObject OrbShard = Instantiate (AttackIce, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f))) * 15f;
		}

	private void Orb3(){
			GameObject OrbShard = Instantiate (AttackIce, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb4(){
			GameObject OrbShard = Instantiate(AttackIce, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb5(){
			GameObject OrbShard = Instantiate (AttackIce, AttackIcePos5.position, AttackIcePos5.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 45) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb6(){
			GameObject OrbShard = Instantiate (AttackIce, AttackIcePos6.position, AttackIcePos6.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb7(){
		
		GameObject OrbShard = Instantiate (AttackIce, AttackIcePos7.position, AttackIcePos7.rotation) as GameObject;
			 OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 15f;
		}
	private void Orb8(){
		
		GameObject OrbShard = Instantiate (AttackIce, AttackIcePos8.position, AttackIcePos8.rotation) as GameObject;
			OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 15f;
		}
	
	
	void Start () {
		GameObject.DestroyObject(gameObject,2.1f);
		
		InvokeRepeating ("Orb1", 0.5f, 0.1f);
		InvokeRepeating ("Orb2", 0.5f, 0.1f);
		InvokeRepeating ("Orb3", 0.5f, 0.1f);
		InvokeRepeating ("Orb4", 0.5f, 0.1f);
		InvokeRepeating ("Orb5", 0.5f, 0.1f);
		InvokeRepeating ("Orb6", 0.5f, 0.1f);
		InvokeRepeating ("Orb7", 0.5f, 0.1f);
		InvokeRepeating ("Orb8", 0.5f, 0.1f);

		InvokeRepeating ("Orb1", 2f, 0.03f);
		InvokeRepeating ("Orb2", 2f, 0.03f);
		InvokeRepeating ("Orb3", 2f, 0.03f);
		InvokeRepeating ("Orb4", 2f, 0.03f);
		InvokeRepeating ("Orb5", 2f, 0.03f);
		InvokeRepeating ("Orb6", 2f, 0.03f);
		InvokeRepeating ("Orb7", 2f, 0.03f);
		InvokeRepeating ("Orb8", 2f, 0.03f);
		
		Player script = PlayerF.GetComponent<Player>();
		
	}
	// Update is called once per frame
	void Update () {
		
		
		
		transform.Rotate (0,0,-15f);
	}
	// Rotates the Orb
}
