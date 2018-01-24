using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	public GameObject mazePoint;
	public static int layerNumber = 5;
	public static int multipleNumber = 2;
    public static float floorPositionY;
    GameObject[,,] mazePointArray;
	public Vector3[,,] mazePointCoordinates;
    int fallCount;


	void Awake(){
		mazePointCoordinates = new Vector3[layerNumber,layerNumber,layerNumber];
        mazePointArray = new GameObject[layerNumber, layerNumber, layerNumber];
		CreateMaze();
	}


	// Use this for initialization
	void Start () {
        fallCount = 0;

	}
	
	// Update is called once per frame
	void Update () {
        fallMase();
		
	}

	void CreateMaze(){
        //床の高さを取得。
        //何も無い時は-10を指定
        floorPositionY = -10f;


		//親オブジェクトを作って、そこから子供を3重ループで作る
		//親オブジェクトの子供にしていく
		GameObject mazeParent = new GameObject("MazeParent");
		mazeParent.transform.position = Vector3.zero;

		for(int i = 0; i < layerNumber; i++){
			for(int j = 0; j < layerNumber; j++){
				for(int k = 0; k < layerNumber; k++){
					GameObject point = Instantiate(mazePoint, new Vector3(i * multipleNumber,j * multipleNumber,k * multipleNumber), Quaternion.identity);
					point.transform.parent = mazeParent.transform;
                    mazePointArray[i, j, k] = point;
					mazePointCoordinates[i,j,k] = point.transform.position;
				}
			}
		}
	}

    void fallMase(){
        fallCount++;
        if(fallCount <= 100){
            return;
        }
        fallCount = 0;
        Debug.Log("ClearCount");


        //既に開くなっているときの処理はあとで
        int randomX = Random.Range(0, layerNumber);
        int randomY = Random.Range(0, layerNumber);
        int randomZ = Random.Range(0, layerNumber);

        //mazePointArrayを利用して落とす命令を送る
        if(!isFall(randomX,randomY,randomZ)){
            Debug.Log("Falling");
            mazePointArray[randomX, randomY, randomZ].SendMessage("Fall");
        }



    }

    bool isFall(int x, int y,int z){
        return mazePointArray[x, y, z].GetComponent<MazePointScript>().isFalling;
        
        
    }
}
