using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour {

	public Transform spawnPos;
	public GameObject spawnee;
	public GameObject coin;
	public Material level2;
	public float initCreationTime = 2f;
	public float creationTime;
	Vector3 tempPos, tempScale, lastTempPos = new Vector3(0,0,0);
	int your_score = 0;

	[SerializeField] private float floorsMeanDist = 5f;
	[SerializeField] private float floorsHeightDist = 5f;

	void Start(){
//		creationTime = initCreationTime;
		//Vector3[]  locations= {new Vector3(-5,1,5),new Vector3(5,1,5),new Vector3(0,1,0),new Vector3(0,1,10)};
		tempPos = spawnPos.position - new Vector3(0,0,0);
		for (int i = 0; i < 200; i++) {
			tempPos.y += floorsHeightDist;
			spawnee.transform.localScale = new Vector3(Random.Range (7, 16),1,(Random.Range (7, 16))); 
			tempPos.x = Random.Range (-16, 16); 
			tempPos.z = Random.Range (-16, 16); 
			if (i >= 2) {
			spawnee.transform.GetComponent<Renderer> ().material = level2;
			}

			GameObject text = new GameObject();
			TextMesh t = text.AddComponent<TextMesh>();
			string s = (i+1).ToString ();
			t.text = s;
			t.fontSize = 5;
			t.transform.position = tempPos;
			//text.transform.SetParent(spawnee.transform, false);

			//spawnee.transform.GetComponent<Renderer> ().material = level2;
			Instantiate (spawnee, tempPos, spawnPos.rotation);
			//Random coins
			int rand = Random.Range (0, 3);
			if (rand == 1) {
				Vector3 pos = tempPos + new Vector3 (0, 1, 0);
				Instantiate (coin, pos, spawnPos.rotation);
			}
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
