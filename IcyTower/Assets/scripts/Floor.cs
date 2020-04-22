using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private Vector3 tempPos;
	public float downSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		tempPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		tempPos.y -= downSpeed;
		transform.position = tempPos;
	}
}
