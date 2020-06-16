using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	float maxPos;
	float minPos;
	private Scene scene;

	public float speed = 2f;
	public float jumpForce = 10f;
	private Rigidbody ball;
	private bool onGround = false;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
		maxPos = 7f;
		minPos = 0f;
		scene = SceneManager.GetActiveScene ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float movemHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movemHor, 0, moveVer);
		ball.AddForce (speed*movement);
		if (Input.GetButtonDown ("Jump") && onGround) {
			//ball.AddForce (Vector3.up*jumpForce, ForceMode.Impulse);
			onGround = false;
			ball.velocity = new Vector3(0, 10, 0);
		}

		if (maxPos < this.transform.position.y) 	// detect player reach new height
		{
			maxPos = this.transform.position.y;
			//			Debug.Log ("player max pos: " + maxPos.ToString ());
			minPos = maxPos - 7;
		}

		if (this.transform.position.y < minPos) 	// detect falling
		{
			Debug.Log ("game over");
			Application.LoadLevel (scene.name);     // restart the game whene the player is falling
		}
	}

	public float GetMaxPos(){
		return maxPos;
	}

	public float GetMinPos(){
		return minPos;
	}

	void OnCollisionStay(Collision col)
	{
		if (col.transform.tag == "cube" || col.gameObject.name == "Plane") {
			onGround = true;
			//Debug.Log ("on ground");
		}	
	}
}
