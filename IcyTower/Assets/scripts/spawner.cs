using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public float initCreationTime = 2f;
	public float creationTime;
	Vector3 tempPos;

	void Start(){
//		creationTime = initCreationTime;
		tempPos = spawnPos.position;
		for (int i = 0; i < 100; i++) {
			tempPos.y += 5;
			Instantiate (spawnee, tempPos, spawnPos.rotation);
		}
	}
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButton (0)) {
//			Instantiate (spawnee, spawnPos.position, spawnPos.rotation);
//		}

//		if (creationTime > 0) {
//			creationTime -= Time.deltaTime;
//
//			if (creationTime <= 0) {
//				Instantiate (spawnee, spawnPos.position, spawnPos.rotation);
//				creationTime = initCreationTime;
//			}
//
//		}
	}
}
