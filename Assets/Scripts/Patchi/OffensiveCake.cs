using UnityEngine;
using System.Collections;

public class OffensiveCake : MonoBehaviour {
	

	float TimeCake = -1f;

	bool CakeFireOne = true;
	bool CakeFireTwo = true;
	bool CakeFireThree = true;
	bool CakeFireFour = true;

	public GameObject AttackCake;
	public Transform PosA;
	public Transform PosB;
	public Transform PosC;
	public Transform PosD;


	// Use this for initialization
	void Start () {
		GameObject.DestroyObject(gameObject,0.52f);


		TimeCake = 0.5f + Time.time;

	


	}
	
	// Update is called once per frame
	void Update () {
		if(TimeCake < Time.time)
		{
			if(CakeFireOne == true)
			{
			GameObject Cake = Instantiate(AttackCake, PosA.position, PosA.rotation) as GameObject;
			Cake.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f)),
			                                        Mathf.Sin((transform.eulerAngles.z + 45f) * (Mathf.PI / 180f))) * 1f;
				CakeFireOne = false;
			}

			if(CakeFireTwo == true)
			{
			GameObject CakeTwo = Instantiate(AttackCake, PosB.position, PosB.rotation) as GameObject;
			CakeTwo.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f)),
			                                           Mathf.Sin((transform.eulerAngles.z + 135f) * (Mathf.PI / 180f))) * 1f;
				CakeFireTwo = false;
			}

			if(CakeFireThree == true)
			{
				GameObject CakeThree = Instantiate(AttackCake, PosC.position, PosC.rotation) as GameObject;
				CakeThree.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z - 135f) * (Mathf.PI / 180f)),
				                                           Mathf.Sin((transform.eulerAngles.z - 135f) * (Mathf.PI / 180f))) * 1f;
				CakeFireThree = false;
			}

			if(CakeFireFour == true)
			{
				GameObject CakeFour = Instantiate(AttackCake, PosD.position, PosD.rotation) as GameObject;
				CakeFour.rigidbody2D.velocity = new Vector2(Mathf.Cos((transform.eulerAngles.z - 45f) * (Mathf.PI / 180f)),
				                                             Mathf.Sin((transform.eulerAngles.z - 45f) * (Mathf.PI / 180f))) * 1f;
				CakeFireFour = false;
			}
			
		}
			
	}
	


}

