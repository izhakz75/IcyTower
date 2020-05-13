using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float maxPos;

	// Use this for initialization
	void Start () {
		maxPos = 7f;
	}
	
	// Update is called once per frame
	void Update () {
		if (maxPos < this.transform.position.y) {
			maxPos = this.transform.position.y;
			Debug.Log ("player max pos: " + maxPos.ToString ());
		}
	}

	public float GetMaxPos(){
		return maxPos;
	}
}
