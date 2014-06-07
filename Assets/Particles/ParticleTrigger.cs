using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour {

	public float timeStart;
	public float timeStop;

	// Use this for initialization
	void Start () {
		GameEventManager.TimeChange += StartParticles; 
	}

	void StartParticles (float time)
	{
		if (time >= timeStart)
		{
			particleSystem.Play(true);
			GameEventManager.TimeChange -= StartParticles;
			GameEventManager.TimeChange += StopParticles;
		}

		if (time >= timeStop)
		{
			particleSystem.Stop(true);
		}
	}

	void StopParticles (float time)
	{
		
		if (time >= timeStop)
		{
			particleSystem.Stop(true);
			GameEventManager.TimeChange -= StopParticles;
		}
	}

}
