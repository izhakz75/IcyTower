using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	private Vector3 backwardDir;
	private Vector3 leftDir;
	private Vector3 rightDir;
	private bool isBackward = false;
	public Text Score;
	int your_score = 0;
	float yPos = 5;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
		maxPos = 7f;
		minPos = 0f;
		scene = SceneManager.GetActiveScene ();
		ballRenderer = this.GetComponent<Renderer> ();
		forwardDir = new Vector3 (1, 0, 0);
		backwardDir = new Vector3 (-1, 0, 0);
		rightDir = new Vector3 (0, 0, -1);
		leftDir = new Vector3 (0, 0, 1);
		ball.velocity = Vector3.zero;
		isBackward = false;
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

		isBackward = Vector3.Dot (forwardDir, ball.velocity) < 0;

		if (ball.velocity.magnitude != 0f) {
			forwardDir = Vector3.Normalize (ball.velocity);
			forwardDir.y = 0;
			backwardDir = -1f * forwardDir;
			leftDir = Vector3.Cross (forwardDir, Vector3.up);
			rightDir = -1f * leftDir;

			if (isBackward) {
				forwardDir = -1f * forwardDir;
				backwardDir = -1f * backwardDir;
				leftDir = -1f * leftDir;
				rightDir = -1f * rightDir;
			}
//			Debug.Log (ball.velocity.magnitude.ToString ());
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			ball.AddForce (force * (forwardDir));

//			Debug.Log ("up key is pressed");
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			ball.AddForce (force * (backwardDir));
//			Debug.Log ("right key is pressed");
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			ball.AddForce (force * (rightDir));
			//			Debug.Log ("right key is pressed");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			ball.AddForce (force * (leftDir));
			//			Debug.Log ("left key is pressed");
			//			Debug.Log (forwardDir.ToString ());
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
		//Debug.Log ("is backward = " + isBackward.ToString ());
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
			if (this.transform.position.y > yPos) {
				addScore (1);// add your own score
				yPos += 5;
				//Destroy(coll.gameObject);
			}
		}
		if (coll.transform.tag == "coin") {
			Destroy(coll.gameObject);
			addScore (1);
		}
	}

	public Vector3 GetForwardDir(){
		return forwardDir;
	}

	void addScore(int points_to_add) {
		your_score += points_to_add;
		Score.text = "Score: " + your_score;
	}
}
