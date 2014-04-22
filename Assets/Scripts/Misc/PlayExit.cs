using UnityEngine;
using System.Collections;

public class PlayExit : MonoBehaviour {
	
	
	public string levelToLoad;
	public bool QuitButton = false;
	
	// Use this for initialization
	void Start () {
	Screen.showCursor = true;
	}
	
	// This is for the menu when you have to press a button with the mouse
	// this will make sure you can play , retry or exit the game
	
	void OnMouseUp(){
	
		if(QuitButton){
			Application.Quit();
		}
		else{
			Application.LoadLevel(levelToLoad);
			
		}
	}
}
