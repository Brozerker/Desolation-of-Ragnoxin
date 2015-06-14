using UnityEngine;
using System.Collections;

public class Quit_ButtonController : MonoBehaviour {
	
	public AudioClip over;
	public AudioClip pressed;
	private AudioSource source;
	private bool isOver = false;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		source.PlayOneShot (pressed);
		Debug.Log ("Starting Level 1");
		Application.Quit();
		// Application.Quit doesn't work in the editor, so the next line closes the game there instead
		UnityEditor.EditorApplication.isPlaying = false;
	}

	void OnMouseOver()
	{
		if (!isOver){
			source.PlayOneShot (over);
			isOver = true;
		}
	}

	void OnMouseExit()
	{
		isOver = false;
	}
}
