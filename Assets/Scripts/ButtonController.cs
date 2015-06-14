using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	
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
		Application.LoadLevel(Application.loadedLevel+1);
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
