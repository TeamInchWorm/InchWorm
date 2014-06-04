using UnityEngine;
using System.Collections;

public class GameEventManager : MonoBehaviour {

	public static int currentScene = 0;

	//Declare generic game event taking no arguments, sets up two basic events
	public delegate void GameEvent();
	public static event GameEvent GameStart, GameOver;

	//Set up the scene event, whatever calls this (audio manager?) will need to pass in the
	//int of the next location it wants to move  to
	public delegate void SceneEvent(int currentScene);
	public static event SceneEvent SceneChange; 
	
	public AudioClip musicTrack;
	public float musicVolume; // 0f to 1f (100% volume)

	private float timeElapsed;

	/*
	 * Call this to start the game. Anything that needs to be changed at the begining of the game
	 * should subscribe to the GameStart event in either Start() or Awake(), for instance...
	 *
	 * void Start() 
	 * {
	 *   GameEventManager.GameStart += ResetLocation;
	 * }
	 *
	 * Notice that both GameStart and ResetLocation in this instance are refrences to the methods themselves
	 * not calls to execute them, or put another way, no parenthesis. Calling the TriggerXXXXX method is what 
	 * actually calls the methods as long as something is subcrsibed (null check)
	 *
	 */

	public static void TriggerGameStart()
	{

		if (GameStart != null) {
			GameStart();	
		}
	}

	//Same as above but on the end of the game
	public static void TriggerGameOver()
	{
		if (GameOver != null) {
			GameOver();	
		}
	}

	//Same as above, but takes the int of the scene location
	public static void TriggerSceneChange(int newScene)
	{
		if (SceneChange != null) {
			SceneChange(newScene);	
		}
	}

	public static void TriggerNextScene()
	{
		currentScene++;
		if (SceneChange != null) {
		
			SceneChange(currentScene);	
		}
	}

	/*
	 * Feel free to use the above as a template for creating new events
	 * for instance WormStuck, MusicBeat, etc
	 * Just remember to subcribe with += in Start or Awake
	 * Also unsubcribe with -= in OnDestroy or it will try calling on objects that don't exist
	 * And then have some other object call the TriggerXXXXX function to activate the event
	 * And you can put more code in the TriggerXXXXX methods if needed as well (sceneChangesMade++;)
	 * or whatever is useful
	 * 
	 *
	 */


}
