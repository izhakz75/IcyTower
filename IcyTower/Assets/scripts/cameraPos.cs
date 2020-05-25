using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraPos : MonoBehaviour {

	public Ball player;
	Vector3 tempPos;

	void Start(){
		tempPos = this.transform.position;
	}
	// Update is called once per frame
	void LateUpdate () {
		tempPos.y = player.GetMaxPos ();
		this.transform.position = tempPos;
	}
}
