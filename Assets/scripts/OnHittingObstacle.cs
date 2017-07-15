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

    void OnTriggerEnter(Collider col)
    {
		//StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().ModifyPoints(-10));
    }
}
