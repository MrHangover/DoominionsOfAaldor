using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {



	GameObject ActivePlayer;
	
	string offensive = "Ready";
	string movement = "Ready";
	string defensive = "Ready";
	string ult = "Ready";

	public bool Begin = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	

	}

	void FixedUpdate ()
	{
		ActivePlayer = GameObject.FindWithTag("Player");
		Player Timer = ActivePlayer.GetComponent<Player>();
		
		Debug.Log(Timer.offensiveCDTimer);
		
		if(Timer.offensiveCDTimer > 0f)
		{
			Debug.Log ("lololo");
			string offensive = "Test";
		} else {
			string offensive = "Ready";
		}
		
		if(Timer.movementCDTimer > 0f)
		{
			float movement = Timer.movementCDTimer;
		} else {
			string movement = "Ready";
		}
		
		if(Timer.defensiveCDTimer > 0f)
		{
			float offensive = Timer.defensiveCDTimer;
		} else {
			string offensive = "Ready";
		}
		
		if(Timer.ultCDTimer > 0f)
		{
			float offensive = Timer.ultCDTimer;
		} else {
			string offensive = "Ready";
		}
	}

	void OnGUI() {

		if(Begin)
			{

				GUILayout.BeginArea(new Rect(800,750,400,Screen.width / 2));

				GUILayout.BeginHorizontal();

				GUILayout.BeginVertical();
				GUILayout.Label("Offensive");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label("Movement");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label("Defensive");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label("Ultimate");
				GUILayout.EndVertical();

				GUILayout.EndHorizontal();


				GUILayout.BeginHorizontal();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(0, 30, 50, 50), offensive);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(100, 30, 50, 50), movement);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(200, 30, 50, 50), defensive);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(300, 30, 50, 50), ult);
				GUILayout.EndVertical();
				
				GUILayout.EndHorizontal();

			
				

				GUILayout.EndArea();
		}


	}
}
