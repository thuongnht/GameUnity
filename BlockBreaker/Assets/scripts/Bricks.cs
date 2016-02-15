using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	private int timeHit;
	private LevelManager lm;
	private bool isBreakable;

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable brick
		if (isBreakable) {
			breakableCount++;
		}
		timeHit = 0;
		lm = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 1f);
		if (isBreakable) {
			HandleHit ();
		}
	}

	void HandleHit(){
		timeHit++;
		int maxHits = hitSprites.Length + 1;
		
		if (timeHit >= maxHits) {
			breakableCount--;
			lm.BrickDestroyed();
			SmokeEffect ();
			Destroy (gameObject);
		}
		else {
			LoadSprite();
		}
	}

	void SmokeEffect() {
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void LoadSprite() {
		int spriteIndex = timeHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} 
	}

	//todo remove this method once we can win
	void SimulateWin(){
		lm.LoadNextLevel();
		//lm.LoadLevel ("win");
	}
}
