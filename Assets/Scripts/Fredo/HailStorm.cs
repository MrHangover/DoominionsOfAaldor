using UnityEngine;
using System.Collections;

public class HailStorm : MonoBehaviour { //The HailStorm is of the type "MonoBehaviour"

	public GameObject AttackIce;
	public GameObject AttackOrb;
	public Transform AttackIcePos1;
	public Transform AttackIcePos2;
	public Transform AttackIcePos3;
	public Transform AttackIcePos4;
	public Transform AttackIcePos5;
	public Transform AttackIcePos6;
	public Transform AttackIcePos7;
	public Transform AttackIcePos8; //The different spawn points, and the two kinds of projectile references

	float rotations = 3f; //Initial rotation value, used later on

	GameObject player; //Reference to the gameobject called "player", used later on

	//Maaaaaany functions: All of them spawns a projectile, at an assigned position
	//8 spawning projectiles of type "HailShard", 8 spawning projectiles of type "OrbShard"
	private void Hail1(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail2(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f))) * 15f;
	}
	
	private void Hail3(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail4(){
		GameObject HailShard = Instantiate(AttackIce, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail5(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos5.position, AttackIcePos5.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 45) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail6(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos6.position, AttackIcePos6.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail7(){
		
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos7.position, AttackIcePos7.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 15f;
	}
	private void Hail8(){
		GameObject HailShard = Instantiate (AttackIce, AttackIcePos8.position, AttackIcePos8.rotation) as GameObject;
		HailShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 15f;
	}

	private void Orb1(){
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos1.position, AttackIcePos1.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 90f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb2(){
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos2.position, AttackIcePos2.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 0f) * (Mathf.PI / 180f))) * 20f;
	}
	
	private void Orb3(){
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos3.position, AttackIcePos3.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 270f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb4(){
		GameObject OrbShard = Instantiate(AttackOrb, AttackIcePos4.position, AttackIcePos4.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f)),
		                                            Mathf.Sin((transform.eulerAngles.z + 180f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb5(){
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos5.position, AttackIcePos5.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 45) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb6(){
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos6.position, AttackIcePos6.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 225f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb7(){
		
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos7.position, AttackIcePos7.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 315f) * (Mathf.PI / 180f))) * 20f;
	}
	private void Orb8(){
		
		GameObject OrbShard = Instantiate (AttackOrb, AttackIcePos8.position, AttackIcePos8.rotation) as GameObject;
		OrbShard.rigidbody2D.velocity = new Vector2 (Mathf.Cos ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
		                                             Mathf.Sin ((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 20f;
	}
	
	private void rot(){
		rotations += 1.5f;
	} //Rotation function - It adds 1.5f to the rotation value, every time it is called

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,16f);
		// The HailStorm lasts for 16 seconds
		player = GameObject.FindWithTag("Player"); //Searches for the gameobject with the tag "Player", again used later on

		InvokeRepeating ("rot", 1f, 0.5f); //After 1 second, and every 0.5 seconds, the function "rot" will be called, increasing the rotation of the storm

		InvokeRepeating ("Hail1", 1f, 2f);
		InvokeRepeating ("Hail2", 2.7f, 1.8f);
		InvokeRepeating ("Hail3", 3.5f, 1.6f);
		InvokeRepeating ("Hail4", 4f, 1.4f);
		InvokeRepeating ("Hail5", 6.5f, 1.2f);
		InvokeRepeating ("Hail6", 7.5f, 0.9f);
		InvokeRepeating ("Hail7", 10f, 0.5f);
		InvokeRepeating ("Hail8", 12.5f, 0.2f);
		InvokeRepeating ("Hail8", 12f, 0.2f);
		InvokeRepeating ("Hail4", 10.7f, 0.4f);
		InvokeRepeating ("Hail2", 7.6f, 0.87f);
		InvokeRepeating ("Hail5", 6.3f, 1.2f);
		InvokeRepeating ("Hail3", 4.75f, 1.43f);
		InvokeRepeating ("Hail7", 3.42f, 1.56f);
		InvokeRepeating ("Hail6", 2.3f, 1.7f);
		InvokeRepeating ("Hail1", 1.2f, 1.95f);
		//A gradually increasing amount of "hail shard" functions are called, each firing more often than the previous

		InvokeRepeating ("Orb1", 12.7f, 0.3f);
		InvokeRepeating ("Orb2", 9.7f, 0.65f);
		InvokeRepeating ("Orb3", 7.2f, 1.2f);
		InvokeRepeating ("Orb4", 5.4f, 1.3f);
		InvokeRepeating ("Orb5", 4.2f, 1.45f);
		InvokeRepeating ("Orb6", 3.7f, 1.6f);
		InvokeRepeating ("Orb7", 2.5f, 1.7f);
		InvokeRepeating ("Orb8", 1.2f, 1.9f);
		InvokeRepeating ("Orb8", 1.7f, 1.85f);
		InvokeRepeating ("Orb4", 2.7f, 1.65f);
		InvokeRepeating ("Orb7", 3.2f, 1.54f);
		InvokeRepeating ("Orb6", 4.4f, 1.46f);
		InvokeRepeating ("Orb3", 5.6f, 1.35f);
		InvokeRepeating ("Orb2", 7.7f, 1.2f);
		InvokeRepeating ("Orb5", 9.5f, 0.65f);
		InvokeRepeating ("Orb1", 10.2f, 0.3f);
		//A gradually increasing amount of "orb shard" functions are called, each firing more often than the previous
		InvokeRepeating ("Orb1", 15.9f, 0.05f);
		InvokeRepeating ("Orb2", 15.9f, 0.05f);
		InvokeRepeating ("Orb3", 15.9f, 0.05f);
		InvokeRepeating ("Orb4", 15.9f, 0.05f);
		InvokeRepeating ("Orb5", 15.9f, 0.05f);
		InvokeRepeating ("Orb6", 15.9f, 0.05f);
		InvokeRepeating ("Orb7", 15.9f, 0.05f);
		InvokeRepeating ("Orb8", 15.9f, 0.05f);
		//After 15.9 seconds, all of the Orb functions are called every 0.05 seconds, giving a final burst of projectiles

		//The reason the functions are called in this manner, is to give the impression of a storm that gradually intensifies (shown by the rotation as well)
		//Shooting out projectiles seemingly at random

		//Player script = PlayerF.GetComponent<Player>();
		
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.Rotate(0, 0, rotations); //the rotation of the storm is a variable
		transform.position = player.transform.position; //The position of the storm is altered to be that of the player, every update - making it follow him
		
		
	}
}
