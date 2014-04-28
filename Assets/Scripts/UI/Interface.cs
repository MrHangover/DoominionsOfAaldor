using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public GameObject PauseScreen;


	// Use this for initialization
	void Start () {
		PauseScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
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
			Application.Quit();
		}
	}
}
