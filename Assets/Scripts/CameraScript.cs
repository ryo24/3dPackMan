using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
		if(speed < 0.01f){
			speed = 75f;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		CameraMove();
	}

	void CameraMove(){
		if(Input.GetKey(KeyCode.J)){
			transform.RotateAround(player.transform.position, Vector3.up, Time.deltaTime * speed);
		}
		if(Input.GetKey(KeyCode.L)){
			transform.RotateAround(player.transform.position, Vector3.up, Time.deltaTime * speed * -1f);
		}

		if(Input.GetKey(KeyCode.I)){
			transform.RotateAround(player.transform.position, transform.right, Time.deltaTime * speed);
		}
		if(Input.GetKey(KeyCode.K)){
			transform.RotateAround(player.transform.position, transform.right, Time.deltaTime * speed * -1f);
		}
		if(Input.GetKeyDown(KeyCode.M)){
			transform.position = player.transform.position + new Vector3(0, 1, -5);
			transform.rotation = Quaternion.identity;
		}
	}
}
