using UnityEngine;
using System.Collections;

public class Difficulty_ButtonController : ButtonController {
	private int difficulty = 2, MAX = 1, MIN = 6; // reversed for setting value purposes
	public int button;// button value is assigned in Unity. Increase is 1, decrease is -1;
	Rect rex = new Rect(Screen.width/2 - 10, Screen.height/2 - 70, 20, 20);
	
	void OnGUI() {
		GUI.TextArea(rex, difficulty.ToString());
	}
	
	void OnMouseDown()
	{
		difficulty += button;
		if (difficulty > MIN) {
			difficulty = MIN;
		} else if (difficulty < MAX) {
			difficulty = MAX;
		} else {
			PlayerController.MAX_HEALTH = difficulty;
			PlayerController.MAX_LIVES = difficulty;
			PlayerController.health = difficulty;
			PlayerController.lives = difficulty;

			source.PlayOneShot (pressed);
			Debug.Log ("Difficulty changed by" + button.ToString ());
		}
	}

}
