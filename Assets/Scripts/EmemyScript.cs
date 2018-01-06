using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EmemyScript : MonoBehaviour {
	public float speed;
	bool isMoveing;
	Vector3 presentPosition;
	Vector3 targetPosition;
	Vector3[,,] mazePositions;
	int posX, posY, posZ = 0;

	int count;
	SeekPattern enemySeekPattern;

	enum dirStream{
		up,
		down
	}

	enum SeekPattern{
		Chase,
		Random
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
		enemySeekPattern = SeekPattern.Chase;
		
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if(count > 500){
			count = 0;

		}
	}

	SeekPattern nextSeekPattern(SeekPattern sk){
		int number = (int)sk;
		number++;
		SeekPattern nextSk;
		if(Enum.IsDefined(typeof(SeekPattern), number)){
			nextSk = (SeekPattern)number;
		}else{
			nextSk =(SeekPattern)0;
		}

		return nextSk;
		
	}

	void Chase(){
		
	}

	void Random(){
		
	}
}
