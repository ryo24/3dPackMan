using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 presentPosition;
	Vector3 targetPosition;
	Vector3[,,] mazePositions;
    int indexX, indexY, indexZ = 0;

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
		presentPosition = mazePositions[indexX,indexY,indexZ];
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
			if(Input.GetKey(KeyCode.W) && valid(indexY, dirStream.up)){
				indexY += 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.S) && valid(indexY, dirStream.down)){
				indexY -= 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
			}

			if(Input.GetKey(KeyCode.D) && valid(indexX, dirStream.up)){
				indexX += 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
				Debug.Log("posX = " + indexX);
			}
			if(Input.GetKey(KeyCode.A) && valid(indexX, dirStream.down)){
				indexX -= 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
			}

			if(Input.GetKey(KeyCode.E) && valid(indexZ, dirStream.up)){
				indexZ += 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
			}
			if(Input.GetKey(KeyCode.Q) && valid(indexZ, dirStream.down)){
				indexZ -= 1;
				targetPosition = mazePositions[indexX,indexY,indexZ];
				isMoveing = true;
			}

		}else{

			transform.position += Vector3.Normalize(targetPosition - transform.position) * Time.deltaTime * speed;

			if(Vector3.Distance( transform.position,targetPosition) <= 0.05f){
				Debug.Log("到着！！");
				Debug.Log(presentPosition);

				presentPosition = mazePositions[indexX,indexY,indexZ];
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

		case dirStream.down:
			if(0 < position){
				return true;
			}else{
				return false;
			}

		default:
			Debug.Log("入力ミス");
			return false;
		}
					
	}

	
}
