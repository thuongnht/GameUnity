using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	public float minX = 0.5f;
	public float maxX = 15.5f;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update(){
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void AutoPlay() {
		Vector3 paddlePos = this.transform.position;
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse () {
		float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
		this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlock, minX, maxX), this.transform.position.y, this.transform.position.z);
	}
}
