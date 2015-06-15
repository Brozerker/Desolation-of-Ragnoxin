using UnityEngine;
using System.Collections;

public class Quit_ButtonController : ButtonController {

	void OnMouseDown()
	{
		source.PlayOneShot (pressed);
		Debug.Log ("Starting Level 1");
		Application.Quit();
		// Application.Quit doesn't work in the editor, so the next line closes the game there instead
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
