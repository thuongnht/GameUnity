using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public int maxHits;
	private int timeHit;
	private LevelManager lm;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		timeHit = 0;
		lm = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	void OnCollisionEnter2D(Collision2D collision) {
		timeHit++;
		if (timeHit >= maxHits) {
			Destroy (gameObject);
		}
		else {
			LoadSprite();
		}
	}

	void LoadSprite() {
		int spriteIndex = timeHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites [spriteIndex];
	}

	//todo remove this method once we can win
	void SimulateWin(){
		lm.LoadNextLevel();
		//lm.LoadLevel ("win");
	}
}
