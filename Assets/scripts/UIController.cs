using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPoints(string points) {
		GameObject pts = GameObject.Find ("pts");
		if (pts) {
			pts.GetComponent<Animator> ().SetTrigger ("GotPoints");
			pts.GetComponent<TextMesh> ().text = points;
		}
	}
}
