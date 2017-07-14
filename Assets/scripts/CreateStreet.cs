using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStreet : MonoBehaviour {
    private Object street;

	// Use this for initialization
	void Start () {
        street = Resources.Load("Prefabs/Prefab_Street1");
        Instantiate(street);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
