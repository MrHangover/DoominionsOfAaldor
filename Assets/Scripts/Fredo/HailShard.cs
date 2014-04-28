using UnityEngine;
using System.Collections;

public class HailShard : Projectile {
	
	public GameObject PlayerF;
	
	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.3f);
		
		
		Player script = PlayerF.GetComponent<Player>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 15);
	}

	protected override void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy")
			dealDamage(other.gameObject, 3, true, 5);
			Slow(other.gameObject,1.5f, 0.75f);
	}

	protected override void OnTriggerEnter2D(Collider2D other){
		
	}
}
