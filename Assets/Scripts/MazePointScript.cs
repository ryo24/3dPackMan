using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePointScript : MonoBehaviour {
    float floorPosition;

    public bool isFalling;

	// Use this for initialization
	void Start () {
        isFalling = false;
        floorPosition = GameManagerScript.floorPositionY;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y <= floorPosition){
            Destroy(gameObject);
        }
		
	}

    public void Fall(){
        var rg = gameObject.AddComponent<Rigidbody>();
        rg.useGravity = true;
        isFalling = true;
    }
}
