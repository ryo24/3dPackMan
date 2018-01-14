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
    int indexX, indexY, indexZ;

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
        indexX = 5;
        indexY = 5;
        indexZ = 5;

		mazePositions = GameObject.Find("GameManager").GetComponent<GameManagerScript>().mazePointCoordinates;
		presentPosition = mazePositions[indexX,indexY,indexZ];
		enemySeekPattern = SeekPattern.Chase;
		
	}
	
	// Update is called once per frame
	void Update () {
        RandomWalk();
		//count++;
		//if( count > 500){
		//	count = 0;
  //          enemySeekPattern = nextSeekPattern(enemySeekPattern);
		//}
        //switch(enemySeekPattern){
        //    case SeekPattern.Chase:
        //        ChaseWalk();
        //        break;
        //    case SeekPattern.Random:
        //        RandomWalk();
        //        break;
        //    default:
        //        ChaseWalk();
        //        break;
        //}
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

    void ChaseWalk(){
		
	}

    void RandomWalk(){
        int randomDir = UnityEngine.Random.Range(0, 5);
        //bool StreamDir = (UnityEngine.Random.value > 0.5f) ? true : false;

        if(!isMoveing){
            switch (randomDir){
                case 0:
                    if (valid(indexY, dirStream.up)) {
                        indexY += 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                    }
                    break;
                case 1:
                    if (valid(indexY, dirStream.down)) {
                        indexY -= 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                    }
                    break;

                case 2:
                    if (valid(indexX, dirStream.up)) {
                        indexX += 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                        Debug.Log("posX = " + indexX);
                    }
                    break;

                case 3:
                    if (valid(indexX, dirStream.down)) {
                        indexX -= 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                    }
                    break;

                case 4:
                    if (valid(indexZ, dirStream.up)) {
                        indexZ += 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                    }
                    break;

                case 5:
                    if (valid(indexZ, dirStream.down)) {
                        indexZ -= 1;
                        targetPosition = mazePositions[indexX, indexY, indexZ];
                        isMoveing = true;
                    }
                    break;
                default:
                    break;
            }
        }else{
            transform.position += Vector3.Normalize(targetPosition - transform.position) * Time.deltaTime * speed;

            if (Vector3.Distance(transform.position, targetPosition) <= 0.05f) {
                Debug.Log("敵到着！！");
                Debug.Log(presentPosition);

                presentPosition = mazePositions[indexX, indexY, indexZ];
                targetPosition = Vector3.zero;

                isMoveing = false;
            }        
        }
		
	}

    bool valid(int position, dirStream ds) {

        switch (ds) {
            case dirStream.up:
                if (position < GameManagerScript.layerNumber - 1) {
                    return true;
                }
                else {
                    return false;
                }

            case dirStream.down:
                if (0 < position) {
                    return true;
                }
                else {
                    return false;
                }

            default:
                Debug.Log("入力ミス");
                return false;
        }

    }


}
