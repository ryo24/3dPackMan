using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		isMoveing = false;
		if(speed < 0.01f){
			speed = 5f;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//QWE
		//ASD
		//前上奥
		//左下右
		if(!isMoveing){
			if(Input.GetKeyDown(KeyCode.W)){
				transform.position +=  Vector3.up * Time.deltaTime * speed;
			}

			isMoveing = true;
		}else{
			if(transform.position == targetPosition){
				isMoveing = false;
			}
		}



	}
}
