using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour {

	public Transform PlayerTransform;
	private Vector3 _cameraOffset;
	[Range(0.01f,1.0f)]
	public float smoothFactor = 0.5f;

	public bool LookAtPlayer = false;
	// Use this for initialization
	void Start () {
		_cameraOffset = transform.position - PlayerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = PlayerTransform.position + _cameraOffset;
		transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor);
		if (LookAtPlayer) {
			transform.LookAt (PlayerTransform);
		}
	}
}
