﻿using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("entered");
            Application.LoadLevel(1);
        }
	
	}
	
}
