using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	private float padding = 0.5f;
	private float minX = -5;
	private float maxX = 5;

	// Use this for initialization
	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		//restrict player into gamespace
		float newX = Mathf.Clamp (this.transform.position.x, minX, maxX);
		this.transform.position = new Vector3 (newX, this.transform.position.y, this.transform.position.z);
	}
}
