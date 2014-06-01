using UnityEngine;
using System.Collections;

public class TestSceneEvents : MonoBehaviour {

	public int scene = 0;

	void OnMouseDown()
	{
		GameEventManager.TriggerSceneChange(scene);
		scene++;
		print ("Current scene is " + scene);
	
	}
}
