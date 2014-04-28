using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	GameObject ActivePlayer;

	bool Begin = false;

	string stringToEdit = "Hello";

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
					stringToEdit = "page 1";
					Done ();
				}

				if(TextThree)
				{
					stringToEdit = "page 2";
					Done ();
				}

				if(TextFour)
				{
					stringToEdit = "page 3";
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
