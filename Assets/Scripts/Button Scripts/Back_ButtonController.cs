using UnityEngine;
using System.Collections;

public class Back_ButtonController : ButtonController {

	void OnMouseDown()
	{
		source.PlayOneShot (pressed);
		Debug.Log ("Back to Start");
		if (Application.loadedLevel == 5) {
			Application.LoadLevel (0);
		} else {
			Application.LoadLevel (5);
		}
	}
}
