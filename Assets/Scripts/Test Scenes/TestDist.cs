using UnityEngine;
using System.Collections;

public class TestDist : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameEventManager.ScoreChange += ChangeText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ChangeText (float dist) {
		guiText.text = dist.ToString("0000.00");
	}
}
