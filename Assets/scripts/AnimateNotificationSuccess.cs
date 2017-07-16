using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateNotificationSuccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowSuccess() {
		transform.localScale = new Vector3 (0.3f, 0.3f, 1);
		yield return new WaitForSeconds(4);
		transform.localScale = Vector3.zero;
	}
}
