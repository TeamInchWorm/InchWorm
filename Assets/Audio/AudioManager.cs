using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager> {
	class ClipInfo
	{
		//ClipInfo used to maintain default audio source info
		public AudioSource source { get; set; }
		public float defaultVolume { get; set; }
	}
	
	private List<ClipInfo> m_activeAudio;

	// Uses Awake instead of Start so this begins first thing in the scene, in case any audio plays initially - EG music
	void Awake() { 
		Debug.Log("AudioManager Initializing");
		try {
			transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
			transform.localPosition = new Vector3(0, 0, 0);
		} catch {
			Debug.Log("Unable to find main camera to attach audiomanager");
		}

		m_activeAudio = new List<ClipInfo>();
	}

	public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume) {
		//Create an empty game object
		GameObject soundLoc = new GameObject("Audio: " + clip.name);
		soundLoc.transform.position = soundOrigin;
		
		//Create the source
		AudioSource source = soundLoc.AddComponent<AudioSource>();
		setSource(ref source, clip, volume);
		source.Play();
		Destroy(soundLoc, clip.length); //Remove the source object after clip finished playing
		
		//Set the source as active
		m_activeAudio.Add(new ClipInfo {source = source, defaultVolume = volume} );
		return source;
	}

	private void setSource(ref AudioSource source, AudioClip clip, float volume) {
		source.rolloffMode = AudioRolloffMode.Logarithmic;
		source.dopplerLevel = 0.2f;
		source.minDistance = 150;
		source.maxDistance = 1500;
		source.clip = clip;
		source.volume = volume;
	}
}