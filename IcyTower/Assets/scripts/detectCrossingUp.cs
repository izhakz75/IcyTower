using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCrossingUp : MonoBehaviour {

//	public GameObject player;
	float playerMaxPos;
	float maxViewPos = 7f;
	float diffMaxPos = 0f;
	[SerializeField] Camera cam;
	Vector3 tempPos;

	void Start () {
		playerMaxPos = this.transform.position.y;
		tempPos = cam.transform.position;
	}
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > maxViewPos) {
			maxViewPos = this.transform.position.y;
			diffMaxPos = this.transform.position.y - maxViewPos;
//			tempPos.y += diffMaxPos;
			//cam.transform.up(diffMaxPos);
			Debug.Log ("up crossing, cam pos: " + cam.transform.position.y.ToString ());
		}

		Debug.Log ("cam pos: " + cam.transform.position.y.ToString ());
		Debug.Log ("max pos: " + maxViewPos.ToString ());
		Debug.Log ("player pos: " + this.transform.position.y.ToString ());
	}

	void OnTriggerEnter(){
		
	}
}
