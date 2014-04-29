using UnityEngine;
using System.Collections;

public class OrbofIce : MonoBehaviour { //OrbofIce is not a projectile as per se, hence it's classified as "MonoBehaviour"
	

	// Use this for initialization

	public GameObject AttackIce;
	public Transform AttackIcePos1;
	public Transform AttackIcePos2;
	public Transform AttackIcePos3;
	public Transform AttackIcePos4;
	public Transform AttackIcePos5;
	public Transform AttackIcePos6;
	public Transform AttackIcePos7;
	public Transform AttackIcePos8; //The 8 spawn points for the orb, as well as a reference to the gameobject known as "AttackIce" in this script

	
	private void Orb1(){ //Commented at bottom
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
		} //Each of the 8 spawn points got their own function, each time the function is called, an OrbShard is spawned at the appropriate spawnpoint
			//at an appropriate angle (45 degrees in between each other). The Shard is shot at speed 15.
	
	
	void Start () {
		GameObject.DestroyObject(gameObject,2.1f);
		// The orb is destroyed after 2.1 seconds
		InvokeRepeating ("Orb1", 0.5f, 0.1f);
		InvokeRepeating ("Orb2", 0.5f, 0.1f);
		InvokeRepeating ("Orb3", 0.5f, 0.1f);
		InvokeRepeating ("Orb4", 0.5f, 0.1f);
		InvokeRepeating ("Orb5", 0.5f, 0.1f);
		InvokeRepeating ("Orb6", 0.5f, 0.1f);
		InvokeRepeating ("Orb7", 0.5f, 0.1f);
		InvokeRepeating ("Orb8", 0.5f, 0.1f);
		//After 0.5 seconds, the 8 functions will each be called every 0.1 seconds

		InvokeRepeating ("Orb1", 2f, 0.03f);
		InvokeRepeating ("Orb2", 2f, 0.03f);
		InvokeRepeating ("Orb3", 2f, 0.03f);
		InvokeRepeating ("Orb4", 2f, 0.03f);
		InvokeRepeating ("Orb5", 2f, 0.03f);
		InvokeRepeating ("Orb6", 2f, 0.03f);
		InvokeRepeating ("Orb7", 2f, 0.03f);
		InvokeRepeating ("Orb8", 2f, 0.03f);
		//After 2 seconds, the orb will fire a shard every 0.03 seconds, from every spawn point, in addition to the 'normal' spawn rate
		//This gives the orb the final burst of projectiles, before being despawned.
		
	
		
	}
	// Update is called once per frame
	void Update () {
		
		
		
		transform.Rotate (0,0,-15f); //The Orb rotates around it's z-axis
	}

}
