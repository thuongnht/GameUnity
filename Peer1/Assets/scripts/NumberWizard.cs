using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;

	public int maxGuessesAllow = 5;
	public Text text;

	// Use this for initialization
	void Start () {
		startGame ();
	}

	void startGame() {
		max = 1000;
		min = 1;

		guess = Random.Range(min, max+1);
		text.text = guess.ToString ();
	}
	
	public void GuessHigher() {
		min = guess;
		nextGuess();
	}

	public void GuessLower() {
		max = guess;
		nextGuess();
	}

	public void GuessRight() {

	}

	public void QuitToStart() {
		
	}

	void nextGuess() {
		guess = Random.Range(min, max+1);
		text.text = guess.ToString();
		maxGuessesAllow -= 1;
		if (maxGuessesAllow <= 0) {
			Application.LoadLevel("win");
		}
	}

}
