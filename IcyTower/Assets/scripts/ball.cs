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
	private Renderer ballRenderer;
	Color ballCol = Color.red;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
		maxPos = 7f;
		minPos = 0f;
		scene = SceneManager.GetActiveScene ();
		ballRenderer = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (onGround){
			if (Input.GetButtonDown ("Jump")) {
				ball.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
				onGround = false;
			}
		
		}
		float movemHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movemHor, 0, moveVer);
		ball.AddForce (speed*movement);

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
			Debug.ClearDeveloperConsole ();
		}
	}


	public float GetMaxPos(){
		return maxPos;
	}

	public float GetMinPos(){
		return minPos;
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "cube") {
			onGround = true;
			Debug.Log ("on ground");
			ballRenderer.material.SetColor ("_SpecColor", Color.red);
		}	
	}
}
