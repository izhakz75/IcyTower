using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public float initCreationTime = 2f;
	public float creationTime;

	void Start(){
		creationTime = initCreationTime;
	}
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButton (0)) {
//			Instantiate (spawnee, spawnPos.position, spawnPos.rotation);
//		}

		if (creationTime > 0) {
			creationTime -= Time.deltaTime;

			if (creationTime <= 0) {
				Instantiate (spawnee, spawnPos.position, spawnPos.rotation);
				creationTime = initCreationTime;
			}

		}
	}
}
