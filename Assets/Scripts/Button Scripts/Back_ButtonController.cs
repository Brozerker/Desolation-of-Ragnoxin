using UnityEngine;
using System.Collections;

public class Back_ButtonController : MonoBehaviour {

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
		Debug.Log ("Back to Start");
		if (Application.loadedLevel == 5) {
			Application.LoadLevel (0);
		} else {
			Application.LoadLevel(5);
		}
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
