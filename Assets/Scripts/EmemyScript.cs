using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyScript : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 presentPosition;
	Vector3 targetPosition;
	Vector3[,,] mazePositions;
	int posX, posY, posZ = 0;

	int count;

	enum dirStream{
		up,
		down
	}

	// Use this for initialization
	void Start () {
		if(speed < 0.01f){
			speed = 5f;
		}
		count = 0;
		isMoveing = false;
		mazePositions = GameObject.Find("GameManager").GetComponent<GameManagerScript>().mazePointCoordinates;
		presentPosition = mazePositions[posX,posY,posZ];
		
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if(count > 500){
			count = 0;
		}
	}

	void Chase(){
		
	}

	void Random(){
		
	}
}
