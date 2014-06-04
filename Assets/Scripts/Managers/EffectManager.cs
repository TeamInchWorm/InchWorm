using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
	
	public delegate void FXEvent();
	public static event FXEvent FXIncrease, FXDecrease, FXZero, FXMax;
	private float lastScore = 0;

	// Use this for initialization
	void Start () {
		GameEventManager.GameStart += TriggerFXZero;
		GameEventManager.ScoreChange += ScoreHandler;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public static void TriggerFXIncrease()
	{
		if (FXIncrease != null) {
			FXIncrease();	
		}
	}

	public static void TriggerFXDecrease()
	{
		if (FXDecrease != null) {
			FXDecrease();	
		}
	}

	public static void TriggerFXMax()
	{
		if (FXMax != null) {
			FXMax();	
		}
	}

	public static void TriggerFXZero()
	{
		if (FXZero != null) {
			FXZero();	
		}
	}

	private void ScoreHandler(float newScore)
	{
		if (newScore > lastScore)
		{
			TriggerFXIncrease();
		}

		else 
		{
			TriggerFXDecrease();
		}
	}


}
