using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	// Declaration of the variables.

	GameObject ActivePlayer;

	bool Begin = false;

	string stringToEdit = "Hello!";

	bool TextTwo = true;
	bool TextTwoDone = false;

	bool TextThree = false;
	bool TextThreeDone = false;

	bool TextFour = false;
	bool TextFourDone = false;

	float NextTimer = -1f;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	void OnTriggerEnter2D (Collider2D other)
	{
		ActivePlayer = GameObject.FindWithTag("Player");			// Finds the player
		Player Talk = ActivePlayer.GetComponent<Player>();			// Get the player script

		if(other.gameObject.tag == "Player")
		{
			Talk.Speechset();										// Triggers the Speechset function in the player script 
			Begin = true;
			NextTimer = 100f + Time.time;
			Time.timeScale = 0.00006f;								// Slows down the time
		}

	}

	void OnGUI() {
		
		if(Begin)
		{

		
			stringToEdit = GUI.TextField(new Rect(580, 500, 800, 200), stringToEdit, 2000);		// Creates a text field



			// This system is based on the Time.time and is used to create a text system so the player can change page by using the input button

			if(Input.GetButtonUp("Normal"))
			{

				if (NextTimer < Time.time)				// Timer to stop the function to stop the function on every page
					Next ();



				if(TextTwo)
				{
					stringToEdit = "Welcome to Doominions of Aaldor! The Dungeon Crawler game, certainly not based on Aalborg University!";			// changing the text showen to the player
					Done ();							// calling the done function
				}

				if(TextThree)
				{
					stringToEdit = "You're about to embark on a journey filled with danger, and therefore you must be prepared!";
					Done ();
				}

				if(TextFour)
				{
					stringToEdit = " First off, you move your character around, by using the 'WASD'-keys, give it a try!";
					Done ();
				}

			}


			
			
		
		}
		
		
	}

	void Next(){

		// This function controlls what pages that are active

		ActivePlayer = GameObject.FindWithTag("Player");
		Player Talk = ActivePlayer.GetComponent<Player>();

		if(TextTwo && TextTwoDone)
		{
			TextThree = true;
			TextTwo = false;
		}

		if(TextThree && TextThreeDone)
		{
			TextFour = true;
			TextThree = false;
		}

		if(TextFour && TextFourDone)
		{
			TextFour = false;

			Talk.Speechset();
			Begin = false;
			Time.timeScale = 1f;
			GameObject.DestroyObject(gameObject);
		}
			



	}

	void Done(){

		// This function makes sure that a small cooldown is created so it wont run though all the pages at once

		if(TextTwo && !TextTwoDone)
		{
			NextTimer = 0.00001f + Time.time;
			TextTwoDone = true;
		}

		if(TextThree && !TextThreeDone)
		{
			NextTimer = 0.00001f + Time.time;
			TextThreeDone = true;
		}

		if(TextFour && !TextFourDone)
		{
			NextTimer = 0.00001f + Time.time;
			TextFourDone = true;
		}

	}

}
