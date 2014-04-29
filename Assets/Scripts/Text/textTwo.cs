using UnityEngine;
using System.Collections;

public class textTwo : MonoBehaviour {


	// For comments see Text.cs

	GameObject ActivePlayer;
	public string leveltoLoad;
	
	bool Begin = false;
	
	string stringToEdit = "You: I did it! I got through the group rooms, safe and sound!";
	
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
					stringToEdit = "('Voice of the Creators'): Thanks for playing this, the first level of 'Doominions of Aaldor' - Stay tuned for future adventures, taking on the ravenous doominions of Aaldor, and eventually the biggest villain in this Milky Way Galaxy; The Doomlord of Aaldor, Genr Sral!";
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
			Application.LoadLevel(leveltoLoad);
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
