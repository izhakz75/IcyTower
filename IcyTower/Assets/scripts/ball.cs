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
	public Text Combo;
	public Text Wow;
	public Text Amazing;
	public Button PlayAgain;
	int your_score = 0;
	float yPos = 5;
	float sequence = 0;
	float lastYpos = 5;
	float lastSequence = 0;
	public PhysicMaterial Boost;

	void addScore(int points_to_add) {
		your_score += points_to_add;
		Score.text = "Score: " + your_score;
	}

	// Use this for initialization
	void Start () {
		Combo.enabled = false;
		Wow.enabled = false;
		Amazing.enabled = false;
		PlayAgain.gameObject.SetActive(false);
		PlayAgain.onClick.AddListener(startOver);
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
		if(PlayAgain.gameObject.activeSelf == false){
			if (this.transform.position.y > lastYpos + 5 && this.transform.position.y> yPos) {
				Combo.enabled = true;
				lastSequence = sequence;
				sequence = Mathf.Ceil ((this.transform.position.y - yPos) / 5);
				Combo.text = "Combo: " + sequence;
				int diff = (int)(sequence - lastSequence);
				addScore (diff);
			}
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
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				ball.AddForce (force * (forwardDir));
			}

			if (Input.GetKey (KeyCode.DownArrow)) {
				ball.AddForce (force * (backwardDir));
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				ball.AddForce (force * (rightDir));
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				ball.AddForce (force * (leftDir));
			}

			if (Input.GetButtonDown ("Jump") && onGround) {
				//ball.AddForce (Vector3.up*jumpForce, ForceMode.Impulse);
				onGround = false;
				ball.velocity += new Vector3(0, jumpSpeed, 0);
			}

			if (maxPos < this.transform.position.y) 	// detect player reach new height
			{
				maxPos = this.transform.position.y;
				minPos = maxPos - 7;
			}

			if (this.transform.position.y < minPos -5) 	// detect falling
			{
				if (sequence != 0) {
					addSequence (sequence);
					sequence = 0;
					Combo.text = "Combo: 0";
					Combo.enabled = false;
				}
				Debug.Log ("Your Score:" + your_score);
				Debug.Log ("Game Over");
				PlayAgain.gameObject.SetActive(true);

			}
			Debug.DrawRay (transform.position, forwardDir, Color.red);
			Debug.DrawRay (transform.position, rightDir, Color.blue);
			Debug.DrawRay (transform.position, leftDir, Color.yellow);
			//Debug.Log ("is backward = " + isBackward.ToString ());
		}
	}

	void startOver(){
		PlayAgain.gameObject.SetActive(false);
		Application.LoadLevel (scene.name);     // restart the game whene the player is falling
		Debug.ClearDeveloperConsole ();

	}
	public float GetMaxPos(){
		return maxPos;
	}

	public float GetMinPos(){
		return minPos;
	}

	void addSequence(float sequence){
		addScore ((int)(sequence * Mathf.Sqrt (sequence)));// add your own score
		Debug.Log(sequence);
		if (sequence > 10) {
			Wow.enabled = true;
		} else if (sequence > 20) {
			Amazing.enabled = true;
		}
		StartCoroutine(wait2sec());
	}



	IEnumerator wait2sec()
	{
		//yield on a new YieldInstruction that waits for 2 seconds.
		yield return new WaitForSecondsRealtime(2);
		Wow.enabled = false;
		Amazing.enabled = false;
	}
	void OnCollisionEnter(Collision coll)
	{
		//combo 
		if (coll.transform.tag == "cube" || coll.gameObject.name == "Plane") {
			onGround = true;

			if (coll.collider.gameObject.transform.parent.GetComponent<Renderer>().material.name == "Boost (Instance)") {
				ball.velocity += new Vector3(0, jumpSpeed*2, 0);
			}
			//Debug.Log (coll.collider.gameObject.transform.parent.GetComponent<Renderer>().material.name);
			if (this.transform.position.y<= lastYpos+5 && this.transform.position.y> yPos) {
					if (sequence > 0) {
						addSequence (sequence);
						yPos+= (int)(sequence - lastSequence)*5;
						sequence = 0;
						Combo.enabled = false;
					} else {
						addScore (1);
					}
					yPos+= 5;
					//Destroy(coll.gameObject);
				lastYpos = this.transform.position.y;
			}
		}
		if (coll.transform.tag == "coin") {
			Destroy(coll.gameObject);
			addScore (1);
		}

		if (coll.transform.tag == "wall") {
			ball.velocity += new Vector3(0, jumpSpeed, 0);
			forwardDir = -1f * forwardDir;
		}
	}

	public Vector3 GetForwardDir(){
		return forwardDir;
	}
}
