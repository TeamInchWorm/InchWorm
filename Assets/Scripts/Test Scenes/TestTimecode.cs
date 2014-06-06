using UnityEngine;
using System.Collections;

public class TestTimecode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameEventManager.TimeChange += ChangeText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ChangeText (float time)
	{
		guiText.text = time.ToString("000#.##");
	}
	
}