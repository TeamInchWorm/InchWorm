using UnityEngine;
using System.Collections;

public class SceneViewManager : MonoBehaviour {

	//Set Empties up with the points in the scene to switch to durring different points in the song
	public Transform[] sceneLocations;
	
	public Camera mainCamera;


	void Start () {
		//Registering the movement method with the event manager 
		GameEventManager.SceneChange += ChangeScene;

		var AM = AudioManager.Instance; // Instantiate the audio manager
		AM.Play(musicTrack, Vector3.zero, musicVolume); // Start playing the song
	}

	//Takes in an int representing the next location to jump the camera to.
	public void ChangeScene(int currentLocation) {
		mainCamera.transform.position = sceneLocations[currentLocation].transform.position;
	}



}
