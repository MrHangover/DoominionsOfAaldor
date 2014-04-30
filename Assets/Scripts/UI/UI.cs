using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Declaration of the variables.

	Player playerScript;
	GameObject player;
	bool foundPlayer = false;
	string offensive = "Ready";
	string movement = "Ready";
	string defensive = "Ready";
	string ult = "Ready";
	public bool Begin = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(!player)														//If no player was found,
			player = GameObject.FindWithTag("Player");					//try to find a player again.
		else if(player && !foundPlayer){
			foundPlayer = true;
			playerScript = player.GetComponent<Player>();
		}
	}

	void FixedUpdate ()
	{

	}

	void OnGUI() {
		if(Begin && playerScript)
		{
			// Health watcher
			GUI.Box(new Rect(10, 30, 80, 40), playerScript.HealthTracker.ToString());

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

			if(playerScript.UIOffensiveCD)
			{
				GUILayout.BeginVertical();
				GUI.Box(new Rect(0, 30, 80, 40), playerScript.offensiveTrack.ToString("0.0") );
				GUILayout.EndVertical();
			} else {
				GUILayout.BeginVertical();
				GUI.Box(new Rect(0, 30, 80, 40), offensive);
				GUILayout.EndVertical();
			}
			
			if(playerScript.UIDefensiveCD)
			{
				GUILayout.BeginVertical();
				GUI.Box(new Rect(100, 30, 80, 40), playerScript.defensiveTrack.ToString("0.0"));
				GUILayout.EndVertical();
			} else {
				GUILayout.BeginVertical();
				GUI.Box(new Rect(100, 30, 80, 40), defensive);
				GUILayout.EndVertical();
			}

			if(playerScript.UIMovementCD)
			{
				GUILayout.BeginVertical();
				GUI.Box(new Rect(200, 30, 80, 40), playerScript.movementTrack.ToString("0.0"));
				GUILayout.EndVertical();
			} else {
				GUILayout.BeginVertical();
				GUI.Box(new Rect(200, 30, 80, 40), movement);
				GUILayout.EndVertical();
			}

			if(playerScript.UIUltCD)
			{
				GUILayout.BeginVertical();
				GUI.Box(new Rect(300, 30, 80, 40), playerScript.ultTrack.ToString("0.0"));
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
