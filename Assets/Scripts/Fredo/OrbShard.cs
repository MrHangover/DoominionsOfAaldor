using UnityEngine;
using System.Collections;

public class OrbShard : Projectile { //OrbShard is a Projectile

	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.55f);
		//The OrbShard despawns after 0.55seconds
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0, 0, 0);	// it does not rotate
	}
	protected override void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy") {
						dealDamage (other.gameObject, 1, false);
						Slow (other.gameObject, 4f, 0.3f);
			Destroy (this.gameObject); //Destroys the projectile upon impact
				}


	}

	//As the Orb shard is a projectile, it needs additional info:
	//It targets objects of type "Enemy"
	//It deals 1 point of damage, and has no knockback
	//It slows the enemy by 30% for 4 seconds

}
