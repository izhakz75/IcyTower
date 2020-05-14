using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public float initCreationTime = 2f;
	public float creationTime;
	Vector3 tempPos, tempScale;
	int your_score = 0;

	void Start(){
//		creationTime = initCreationTime;
		tempPos = spawnPos.position - new Vector3(0,3,0);
		for (int i = 0; i < 100; i++) {
			tempPos.y += 5;
			tempPos.x = Random.Range (-15, 10); 
			spawnee.transform.localScale = new Vector3(Random.Range (5, 11),1,5); 

			Instantiate (spawnee, tempPos, spawnPos.rotation);
		}
	}


	void OnCollisionEnter (Collision c) {
		Debug.Log(c.gameObject.name);
		if (c.gameObject.name== "Cube (1)") {
		//	addScore("your_score", 10); // add your own score
			Debug.Log("interaction");
			Destroy(c.gameObject);

		}
	}

	void addScore(string variable_name, int points_to_add) {
		//PlayerPrefs.SetInt(variable_name, PlayerPrefs.GetInt(variable_name) + points_to_add);
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
