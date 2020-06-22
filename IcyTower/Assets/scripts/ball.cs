using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	float maxPos;
	float minPos;
	private Scene scene;

	[SerializeField] private float force = 2f;
	public float jumpSpeed = 10f;
	private Rigidbody ball;
	private bool onGround = false;
	private Renderer ballRenderer;
	Color ballCol = Color.red;
	private Vector3 forwardDir;
	private Vector3 leftDir;
	private Vector3 rightDir;
	private bool isBackward = false;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
		maxPos = 7f;
		minPos = 0f;
		scene = SceneManager.GetActiveScene ();
		ballRenderer = this.GetComponent<Renderer> ();
		forwardDir = new Vector3(1,0,0);
		rightDir = new Vector3(0,0,-1);
		leftDir = new Vector3(0,0,1);
		ball.velocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		
//		if (onGround){
//			if (Input.GetButtonDown ("Jump")) {
//				ball.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
//				onGround = false;
//			}
//		
//		}
//		float movemHor = Input.GetAxis ("Horizontal");
//		float moveVer = Input.GetAxis ("Vertical");
//		Vector3 movement = new Vector3 (movemHor, 0, moveVer);
//		ball.AddForce (speed*movement);

		isBackward = false;

		if (ball.velocity.magnitude != 0f) {
			if (!isBackward) {
				forwardDir = Vector3.Normalize (ball.velocity);
			}else{
				forwardDir = -1f*Vector3.Normalize (ball.velocity);
			}

			leftDir = Vector3.Cross (forwardDir, Vector3.up);
			rightDir = -1f * leftDir;
			Debug.Log (ball.velocity.magnitude.ToString ());
		}
			
		if (Input.GetKey (KeyCode.UpArrow)) {
			ball.AddForce (force * (forwardDir));
			Debug.Log ("up key is pressed");
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			ball.AddForce (-force * (forwardDir));
			isBackward = true;
			Debug.Log ("down key is pressed");
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			ball.AddForce (force * (rightDir));
			Debug.Log ("right key is pressed");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			ball.AddForce (force * (leftDir));
			Debug.Log ("left key is pressed");
			Debug.Log (forwardDir.ToString ());
		}

		if (Input.GetButtonDown ("Jump") && onGround) {
			//ball.AddForce (Vector3.up*jumpForce, ForceMode.Impulse);
			onGround = false;
			ball.velocity += new Vector3(0, jumpSpeed, 0);
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
			Debug.ClearDeveloperConsole ();
		}

		Debug.DrawRay (transform.position, forwardDir, Color.red);
		Debug.DrawRay (transform.position, rightDir, Color.blue);
		Debug.DrawRay (transform.position, leftDir, Color.yellow);
	}


	public float GetMaxPos(){
		return maxPos;
	}

	public float GetMinPos(){
		return minPos;
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.transform.tag == "cube" || coll.gameObject.name == "Plane") {
			onGround = true;
			//Debug.Log ("on ground");
		}	
	}

	public Vector3 GetForwardDir(){
		return forwardDir;
	}
}
