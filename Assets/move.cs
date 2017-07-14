using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private Vector3 moveForward = new Vector3(0,0,10);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z"))
        {
            this.transform.position += Vector3.forward;
        }
        if (Input.GetKeyDown("b"))
        {
            this.transform.position += Vector3.back;
        }
        if (Input.GetKeyDown("a"))
        {
            this.transform.position += Vector3.left;
        }
        if (Input.GetKeyDown("l"))
        {
            this.transform.position += Vector3.right;
        }
    }
}
