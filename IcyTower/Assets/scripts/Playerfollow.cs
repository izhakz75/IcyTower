using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour {

	public Transform PlayerTransform;
	private Vector3 _cameraOffset;
	private Vector3 camPos;
	private Vector3 ballPlanarDir = new Vector3 ();
	//[Range(0.01f,1.0f)]
	public float smoothFactor = 0.5f;
	[SerializeField] private Ball ball;
	public bool LookAtPlayer = false;
	[SerializeField] private float distAway;
	[SerializeField] private float distUp;
	[SerializeField] private float smooth;
	private Transform follow;
	// Use this for initialization
	void Start () {
//		_cameraOffset = transform.position - PlayerTransform.position;
		follow = GameObject.FindWithTag ("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 newPos = PlayerTransform.position + _cameraOffset;
//		newPos += new Vector3 (0f, -5f, 5f);
//		transform.position = Vector3.Slerp (transform.position, newPos, smoothFactor);
//		if (LookAtPlayer) {
//			transform.LookAt (PlayerTransform);
//		}
	}

	void LateUpdate(){
		if (ball.GetForwardDir ().y == 0f) {
			camPos = follow.position + Vector3.up * distUp + -distAway * ball.GetForwardDir ();
		}else{
			ballPlanarDir = ball.GetForwardDir ();			
			ballPlanarDir.y = 0f;
			camPos = follow.position + Vector3.up * distUp + -distAway * ballPlanarDir;
		}
		transform.position = Vector3.Lerp (transform.position, camPos, Time.deltaTime * smooth);
		transform.LookAt (follow);
	}
}
