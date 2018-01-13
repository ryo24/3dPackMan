using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip_text : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 presentPosition;
	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		isMoveing = false;
		if(speed < 0.01f){
			speed = 5f;
		}
		presentPosition = Vector3.zero;


	}
	
	// Update is called once per frame
	void Update () {
		//QWE
		//ASD
		//前上奥
		//左下右
		if(!isMoveing){
			if(Input.GetKey(KeyCode.W)){
				targetPosition = presentPosition +  Vector3.up * GameManagerScript.multipleNumber;
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.S)){
				targetPosition = presentPosition +  Vector3.up * GameManagerScript.multipleNumber * -1;
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.D)){
				targetPosition = presentPosition +  Vector3.right * GameManagerScript.multipleNumber;
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.A)){
				targetPosition = presentPosition +  Vector3.right * GameManagerScript.multipleNumber * -1;
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.E)){
				targetPosition = presentPosition +  Vector3.forward * GameManagerScript.multipleNumber;
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.Q)){
				targetPosition = presentPosition +  Vector3.forward * GameManagerScript.multipleNumber * -1;
				isMoveing = true;
			}

		}else{

			transform.position += Vector3.Normalize(targetPosition - transform.position) * Time.deltaTime * speed;

			if(Vector3.Distance( transform.position,targetPosition) <= 0.05f){
				Debug.Log("到着！！");
				Debug.Log(presentPosition);

				presentPosition = transform.position;
				targetPosition = Vector3.zero;

				isMoveing = false;
			}
		}



	}
}
