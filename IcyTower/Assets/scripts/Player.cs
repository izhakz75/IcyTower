using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	float maxPos;
	float minPos;
	private Scene scene;
	// Use this for initialization
	void Start () {
		maxPos = 7f;
		minPos = 0f;
		scene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update () {
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
}
