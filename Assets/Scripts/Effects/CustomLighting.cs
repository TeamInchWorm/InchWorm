using UnityEngine;
using System.Collections;

public class CustomLighting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameEventManager.TimeChange += checkTime; // Add checkTime to GME's time event list
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void checkTime(float currentTime) {

	}
}
