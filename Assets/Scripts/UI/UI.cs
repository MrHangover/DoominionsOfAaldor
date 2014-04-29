using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Declaration of the variables.

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

	}

	void OnGUI() {

		if(Begin)
			{

				// Health watcher

				GUI.Box(new Rect(10, 30, 80, 40), Creature.HealthTracker.ToString());



				// Creates text on the screen

				GUILayout.BeginArea(new Rect(800,760,400,Screen.width / 2));	// Begins the text area

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
				
				// Creates boxes

				if(Player.UIOffensiveCD)
				{
					GUILayout.BeginVertical();
					GUI.Box(new Rect(0, 30, 80, 40), Player.offensiveTrack.ToString("0.00") );
					GUILayout.EndVertical();
				} else {
					GUILayout.BeginVertical();
					GUI.Box(new Rect(0, 30, 80, 40), offensive);
					GUILayout.EndVertical();
				}
				
				
				if(Player.UIDefensiveCD)
				{
					GUILayout.BeginVertical();
					GUI.Box(new Rect(100, 30, 80, 40), Player.movementTrack.ToString("0.00"));
					GUILayout.EndVertical();
				} else {
					GUILayout.BeginVertical();
					GUI.Box(new Rect(100, 30, 80, 40), movement);
					GUILayout.EndVertical();
				}

				if(Player.UIMovementCD)
				{
					GUILayout.BeginVertical();
					GUI.Box(new Rect(200, 30, 80, 40), Player.defensiveTrack.ToString("0.00"));
					GUILayout.EndVertical();
				} else {
					GUILayout.BeginVertical();
					GUI.Box(new Rect(200, 30, 80, 40), defensive);
					GUILayout.EndVertical();
				}

				if(Player.UIUltCD)
				{
					GUILayout.BeginVertical();
					GUI.Box(new Rect(300, 30, 80, 40), Player.ultTrack.ToString("0.00"));
					GUILayout.EndVertical();
				} else {
					GUILayout.BeginVertical();
					GUI.Box(new Rect(300, 30, 80, 40), ult);
					GUILayout.EndVertical();
				}
				

				GUILayout.EndHorizontal();

			
				

				GUILayout.EndArea();						// Ends the text area
		}


	}
}
