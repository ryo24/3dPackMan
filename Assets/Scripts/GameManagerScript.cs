using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	public GameObject mazePoint;
	int layerNumber = 5;

	// Use this for initialization
	void Start () {
		CreateMaze();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateMaze(){
		//親オブジェクトを作って、そこから子供を3重ループで作る
		//親オブジェクトの子供にしていく
		GameObject mazeParent = new GameObject("MazeParent");
		mazeParent.transform.position = Vector3.zero;

		for(int i = 0; i < layerNumber; i++){
			for(int j = 0; j < layerNumber; j++){
				for(int k = 0; k < layerNumber; k++){
					GameObject point = Instantiate(mazePoint, new Vector3(i * 2,j * 2,k * 2), Quaternion.identity);
				}
			}
		}

	}
}
