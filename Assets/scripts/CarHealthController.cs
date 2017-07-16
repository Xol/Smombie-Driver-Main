using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarHealthController : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {	
		health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void damageCar() {
		health--;

		string white_x = GameObject.Find ("health_white").GetComponent<TextMesh> ().text;
		string red_x = GameObject.Find ("health_red").GetComponent<TextMesh> ().text + "x";

		GameObject.Find ("health_white").GetComponent<TextMesh> ().text = white_x.Substring(0, white_x.Length - 1);
		GameObject.Find ("health_red").GetComponent<TextMesh> ().text = red_x;

		if (health == 0) {
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().NotifyMeteor(NotificationTypeEnum.GAME_OVER));
			SceneManager.LoadScene("GameOver");
		}
	}
}
