using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballRolling : MonoBehaviour {

	public float speed = 2f;
	private Rigidbody ball;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float movementHor = Input.GetAxis ("Horizontal");
	}
}
