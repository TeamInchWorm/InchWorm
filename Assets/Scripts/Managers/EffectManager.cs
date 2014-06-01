using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
	
	public delegate void FXEvent();
	public static event FXEvent FXIncrease, FXDecrease, FXZero, FXMax;

	// Use this for initialization
	void Start () {
	
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

	public static void TriggerFXZDecrease()
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


}
