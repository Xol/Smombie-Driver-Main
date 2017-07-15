using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float distance_z = 10;
	public float distance_y = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform car_transform = GameObject.Find ("Car").transform;
		transform.position = new Vector3(transform.position.x, car_transform.position.y + distance_y, car_transform.position.z - distance_z);
		
	}
}
