using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for " + name);
		Bricks.breakableCount = 0;
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Debug.Log ("Level load requested for " + name);
		Bricks.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void QuitRequest() {
		Debug.Log ("Level quit requested for game");
		Application.Quit ();
	}

	public void BrickDestroyed () {
		//last brick destroyed
		if (Bricks.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
