using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public float initCreationTime = 2f;
	public float creationTime;
	Vector3 tempPos, tempScale, lastTempPos = new Vector3(0,0,0);
	int your_score = 0;

	void Start(){
//		creationTime = initCreationTime;
		tempPos = spawnPos.position - new Vector3(0,3,0);
		for (int i = 0; i < 100; i++) {
			tempPos.y += 5;
			tempPos.x = Random.Range (-15, 10); 
			if (tempPos.x < lastTempPos.x - 5.0f) {
				tempPos.x = lastTempPos.x - 5.0f;
			}
			else if (tempPos.x > lastTempPos.x + 5.0f) {
				tempPos.x = lastTempPos.x + 5.0f;
			}
			spawnee.transform.localScale = new Vector3(Random.Range (5, 11),1,5); 

			Instantiate (spawnee, tempPos, spawnPos.rotation);
			lastTempPos = tempPos;
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
