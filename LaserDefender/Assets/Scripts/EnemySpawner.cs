using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	private float width = 10f;
	private float height = 5f;

	private bool movingRight = true;
	private float speed = 25f;
	private Vector3 leftEdge, rightEdge;
	private float minX, maxX;

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		minX = leftEdge.x;
		maxX = rightEdge.x;
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0f));
	}
	
	// Update is called once per frame
	void Update () {
	    if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float leftFormation = transform.position.x - 0.5f * width;
		float rightFormation = transform.position.x + 0.5f * width;
		if (leftFormation < minX) {
			movingRight = true;
		} else if (rightFormation > maxX) {
			movingRight = false;
		}
	}
}
