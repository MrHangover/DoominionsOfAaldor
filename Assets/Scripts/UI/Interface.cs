using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public GameObject PauseScreen;


	// Use this for initialization
	void Start () {
		PauseScreen.SetActive(false);		// Setting a gameobejct to false
	}
	
	// Update is called once per frame
	void Update () {
	
		// a pause button that stops time and brings up the pause screen and if pressed again it the pause and screen will be removed


		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 0f)
			{
				Time.timeScale = 1f;
				PauseScreen.SetActive(false);
			} else {
				Time.timeScale = 0f;
				PauseScreen.SetActive(true);

			}
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();					// Quit button
		}
	}
}
