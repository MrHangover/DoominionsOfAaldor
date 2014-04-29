﻿using UnityEngine;
using System.Collections;

public class TextStart : MonoBehaviour {

	
	GameObject ActivePlayer;
	
	bool Begin = false;
	
	string stringToEdit = "You: What a beutiful day.. bla bla";
	
	bool TextTwo = true;
	bool TextTwoDone = false;
	

	

	
	float NextTimer = -1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		ActivePlayer = GameObject.FindWithTag("Player");
		Player Talk = ActivePlayer.GetComponent<Player>();
		
		if(other.gameObject.tag == "Player")
		{
			Talk.Speechset();
			Begin = true;
			NextTimer = 100f + Time.time;
			Time.timeScale = 0.00006f;
		}
		
	}
	
	void OnGUI() {
		
		if(Begin)
		{
			
			
			stringToEdit = GUI.TextField(new Rect(580, 500, 800, 200), stringToEdit, 2000);
			
			
			
			if(Input.GetButtonUp("Normal"))
			{
				
				if (NextTimer < Time.time)
					Next ();
				
				
				
				if(TextTwo)
				{
					stringToEdit = "You: Ohh.. what was that bla bla bla";
					Done ();
				}
				
			
				
			
				
			}
			
			
			
			
			
		}
		
		
	}
	
	void Next(){
		
		ActivePlayer = GameObject.FindWithTag("Player");
		Player Talk = ActivePlayer.GetComponent<Player>();
		
		if(TextTwo && TextTwoDone)
		{
			TextTwo = false;

			Talk.Speechset();
			Begin = false;
			Time.timeScale = 1f;
			GameObject.DestroyObject(gameObject);
		}

		

		
	
		
		
		
		
	}
	
	void Done(){
		
		
		if(TextTwo && !TextTwoDone)
		{
			NextTimer = 0.00001f + Time.time;
			TextTwoDone = true;
		}
		
	
		
	
		
	}
}
