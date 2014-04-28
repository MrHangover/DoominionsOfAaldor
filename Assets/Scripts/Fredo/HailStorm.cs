using UnityEngine;
using System.Collections;

public class HailStorm : MonoBehaviour {
	
	public GameObject PlayerF;

	public GameObject AttackIce1;
	public Transform AttackIcePos1;
	
	public GameObject AttackIce2;
	public Transform AttackIcePos2;
	
	public GameObject AttackIce3;
	public Transform AttackIcePos3;
	
	public GameObject AttackIce4;
	public Transform AttackIcePos4;
	
	public GameObject AttackIce5;
	public Transform AttackIcePos5;
	
	public GameObject AttackIce6;
	public Transform AttackIcePos6;
	
	public GameObject AttackIce7;
	public Transform AttackIcePos7;
	
	public GameObject AttackIce8;
	public Transform AttackIcePos8;

	float rotations = 3f;

	GameObject player;

	private void Hail1(){
		GameObject HailShard = Instantiate (AttackIce1, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail2(){
		GameObject HailShard = Instantiate (AttackIce2, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f))) * 15f;
	}
	
	private void Hail3(){
		GameObject HailShard = Instantiate (AttackIce3, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail4(){
		GameObject HailShard = Instantiate(AttackIce4, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail5(){
		GameObject HailShard = Instantiate (AttackIce5, AttackIcePos5.position, AttackIcePos5.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 45) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail6(){
		GameObject HailShard = Instantiate (AttackIce6, AttackIcePos6.position, AttackIcePos6.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail7(){
		
		GameObject HailShard = Instantiate (AttackIce7, AttackIcePos7.position, AttackIcePos7.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail8(){
		GameObject HailShard = Instantiate (AttackIce8, AttackIcePos8.position, AttackIcePos8.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 15f;
	}

	private void Orb1(){
		GameObject OrbShard = Instantiate (AttackIce1, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb2(){
		GameObject OrbShard = Instantiate (AttackIce2, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f))) * 20f;
	}
	
	private void Orb3(){
		GameObject OrbShard = Instantiate (AttackIce3, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb4(){
		GameObject OrbShard = Instantiate(AttackIce4, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb5(){
		GameObject OrbShard = Instantiate (AttackIce5, AttackIcePos5.position, AttackIcePos5.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 45) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb6(){
		GameObject OrbShard = Instantiate (AttackIce6, AttackIcePos6.position, AttackIcePos6.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb7(){
		
		GameObject OrbShard = Instantiate (AttackIce7, AttackIcePos7.position, AttackIcePos7.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb8(){
		
		GameObject OrbShard = Instantiate (AttackIce8, AttackIcePos8.position, AttackIcePos8.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 20f;
	}
	
	private void rot(){
		rotations += 0.5f;
	}

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,16f);

		player = GameObject.FindWithTag("Player");

		InvokeRepeating ("rot", 1f, 0.5f);

		InvokeRepeating ("Hail1", 1f, 2f);
		InvokeRepeating ("Hail2", 2.7f, 1.8f);
		InvokeRepeating ("Hail3", 3.5f, 1.6f);
		InvokeRepeating ("Hail4", 4f, 1.4f);
		InvokeRepeating ("Hail5", 6.5f, 1.2f);
		InvokeRepeating ("Hail6", 7.5f, 0.9f);
		InvokeRepeating ("Hail7", 10f, 0.5f);
		InvokeRepeating ("Hail8", 12.5f, 0.2f);

		InvokeRepeating ("Orb1", 14f, 0.3f);
		InvokeRepeating ("Orb2", 14.2f, 0.25f);
		InvokeRepeating ("Orb3", 14.4f, 0.2f);
		InvokeRepeating ("Orb4", 14.5f, 0.1f);
		InvokeRepeating ("Orb5", 14.7f, 0.07f);
		InvokeRepeating ("Orb6", 14.9f, 0.04f);
		InvokeRepeating ("Orb7", 15f, 0.03f);
		InvokeRepeating ("Orb8", 15.3f, 0.01f);




		Player script = PlayerF.GetComponent<Player>();
		
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.Rotate(0, 0, rotations);
		transform.position = player.transform.position;
		
		
	}
}
