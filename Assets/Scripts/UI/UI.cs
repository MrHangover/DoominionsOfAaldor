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
		if(Begin)
		{
			ActivePlayer = GameObject.FindWithTag("Player");
			Player Timer = ActivePlayer.GetComponent<Player>();
			
		
			if(Player.UIOffensiveCD)
			{
				offensive = "Cooldown";
			} else {
				offensive = "Ready";
			}
			
			if(Player.UIDefensiveCD)
			{
				movement = "Cooldown";
			} else {
				movement = "Ready";
			}
		
			if(Player.UIMovementCD)
			{
				defensive = "Cooldown";
			} else {
				defensive = "Ready";
			}
			
			if(Player.UIUltCD)
			{
				ult = "Cooldown";
			} else {
				ult = "Ready";
			}
		}
	}

	void OnGUI() {

		if(Begin)
			{

				GUILayout.BeginArea(new Rect(800,760,400,Screen.width / 2));

				GUILayout.BeginHorizontal();

				GUILayout.BeginVertical();
				GUILayout.Label("  Offensive");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label("  Defensive");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label("  Movement");
				GUILayout.EndVertical();

				GUILayout.BeginVertical();
				GUILayout.Label(" Ultimate");
				GUILayout.EndVertical();

				GUILayout.EndHorizontal();


				GUILayout.BeginHorizontal();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(0, 30, 80, 40), offensive);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(100, 30, 80, 40), movement);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(200, 30, 80, 40), defensive);
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical();
				GUI.Box(new Rect(300, 30, 80, 40), ult);
				GUILayout.EndVertical();
				
				GUILayout.EndHorizontal();

			
				

				GUILayout.EndArea();
		}


	}
}
