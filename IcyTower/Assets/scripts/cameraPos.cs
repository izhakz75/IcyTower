using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPos : MonoBehaviour {

	public Player player;
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
