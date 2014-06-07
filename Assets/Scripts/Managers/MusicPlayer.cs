using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	public Camera mainCamera;
	public AudioClip musicTrack;
	public float musicVolume;


	void Start () {
		var AM = AudioManager.Instance; // Instantiate the audio manager
		AM.Play(musicTrack, Vector3.zero, musicVolume); // Start playing the song
	}

}
