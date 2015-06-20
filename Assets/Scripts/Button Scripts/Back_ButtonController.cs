using UnityEngine;
using System.Collections;

public class Back_ButtonController : ButtonController {

	void OnMouseDown()
	{
		source.PlayOneShot (pressed);
		Debug.Log ("Back to Start");
		Application.LoadLevel (0);
	}
}
