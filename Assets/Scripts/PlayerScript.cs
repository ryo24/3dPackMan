using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 presentPosition;
	Vector3 targetPosition;
	Vector3[,,] mazePositions;
	int posX, posY, posZ = 0;

	enum dirStream{
		up,
		down
	}

	// Use this for initialization
	void Start () {
		if(speed < 0.01f){
			speed = 5f;
		}
		isMoveing = false;
		mazePositions = GameObject.Find("GameManager").GetComponent<GameManagerScript>().mazePointCoordinates;
		presentPosition = mazePositions[posX,posY,posZ];
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		//Q W E
		//A S D
		//前上奥
		//左下右
		if(!isMoveing){
			if(Input.GetKeyDown(KeyCode.W) && valid(posY, dirStream.up)){
				posY += 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.S) && valid(posY, dirStream.down)){
				posY -= 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
			}

			if(Input.GetKey(KeyCode.D) && valid(posX, dirStream.up)){
				posX += 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
				Debug.Log("posX = " + posX);
			}
			if(Input.GetKey(KeyCode.A) && valid(posX, dirStream.down)){
				posX -= 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
			}

			if(Input.GetKey(KeyCode.E) && valid(posZ, dirStream.up)){
				posZ += 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.Q) && valid(posZ, dirStream.down)){
				posZ -= 1;
				targetPosition = mazePositions[posX,posY,posZ];
				isMoveing = true;
			}

		}else{

			transform.position += Vector3.Normalize(targetPosition - transform.position) * Time.deltaTime * speed;

			if(Vector3.Distance( transform.position,targetPosition) <= 0.05f){
				Debug.Log("到着！！");
				Debug.Log(presentPosition);

				presentPosition = mazePositions[posX,posY,posZ];
				targetPosition = Vector3.zero;

				isMoveing = false;
			}
		}
	}

	bool valid(int position, dirStream ds){

		switch(ds){
		case dirStream.up:
			if(position < GameManagerScript.layerNumber - 1){
				return true;
			}else{
				return false;
			}
			break;
		case dirStream.down:
			if(0 < position){
				return true;
			}else{
				return false;
			}
			break;
		default:
			Debug.Log("入力ミス");
			return false;
			break;
		}
					
	}

	
}
