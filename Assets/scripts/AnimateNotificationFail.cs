using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateNotificationFail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowSuccess() {
		transform.localScale = new Vector3 (0.3f, 0.3f, 1);
		transform.GetComponent<Animator> ().SetTrigger ("Fail");
		GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds(1.5f);
		transform.localScale = Vector3.zero;
	}
}
