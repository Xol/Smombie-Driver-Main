using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHittingObstacle : MonoBehaviour
{
    [SerializeField]
    private int deductedPoints = 1;

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
        col.GetComponent<AudioController>().PlaySound();
		GameObject.Find ("Car").GetComponent<CarHealthController> ().damageCar ();
        StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().ModifyPoints(-10));
    }
}
