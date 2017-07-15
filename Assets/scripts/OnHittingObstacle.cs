using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHittingObstacle : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision detected");
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log("Collision2D detected");
    }

    void OnTriggerEnter()
    {
        Debug.Log("Trigger detected");
    }
}
