using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	float damageCD = 0f;

	public void KnockBack(Vector2 force){
		rigidbody2D.velocity = force;
	}

	protected abstract void OnCollisionEnter2D(Collision2D other);

	protected void dealDamage(GameObject player, int damage, bool isKnockBacking, int knockBackForce = 0){
		if(damageCD < Time.time){
			Creature playerScript = player.GetComponent<Creature>();
			playerScript.TakeDamage(damage);
			if(isKnockBacking){
				float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);
				playerScript.KnockBack(new Vector2(Mathf.Cos(angle) * -knockBackForce, Mathf.Sin(angle) * -knockBackForce));
			}
			damageCD = Time.time + 0.25f;
		}
	}

	protected void reflectProjectile(GameObject projectile, Vector2 knockBack){
		Projectile projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.KnockBack(knockBack);
	}
}
