using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPos : MonoBehaviour {

	[SerializeField] private Ball ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ball.transform.position;
	}
}
