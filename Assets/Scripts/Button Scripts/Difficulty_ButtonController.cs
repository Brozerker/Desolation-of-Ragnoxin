using UnityEngine;
using System.Collections;

public class Difficulty_ButtonController : ButtonController {
	private static int difficulty = 2, MAX = 1, MIN = 6; // reversed for setting value purposes
	public int button;// button value is assigned in Unity. Increase is 1, decrease is -1;
	
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

			// Update script that manages difficulty text.
			//This is necessary because two different buttons use this script and were writing two texts to the screen
			Difficulty_Text.difficulty = Difficulty_ButtonController.difficulty; 
			source.PlayOneShot (pressed);
			Debug.Log ("Difficulty changed by" + button.ToString ());
		}
	}

}
