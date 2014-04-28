using UnityEngine;
using System.Collections;

public abstract class Enemy : Creature {

	protected abstract void OnCollisionEnter2D(Collision2D other);

	protected void dealDamage(GameObject player, int damage, bool isKnockBacking, int knockBackForce = 0){
		Creature playerScript = player.GetComponent<Creature>();
		playerScript.TakeDamage(damage);
		if(isKnockBacking){
			float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x);
			playerScript.KnockBack(new Vector2(Mathf.Cos(angle) * -knockBackForce, Mathf.Sin(angle) * -knockBackForce));
		}
	}
}