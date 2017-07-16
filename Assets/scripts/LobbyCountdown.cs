using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyCountdown : MonoBehaviour {

	float timeLeft = 3.0f;
	bool active = false;
	public TextMesh text;

	void Start() {
		text = GameObject.Find ("Countdown").GetComponent<TextMesh> ();
	}

	public void activateCountdown() {
		active = true;
	}

	void Update()
	{
		if (active) {
			timeLeft -= Time.deltaTime;
			text.text = Mathf.Round(timeLeft) + "";
			if(timeLeft < 0) { 
				StartCoroutine(GameObject.Find ("__Meteor").GetComponent<MeteorConnector> ().NotifyMeteor (NotificationTypeEnum.GAME_START));
				SceneManager.LoadScene("smombie-driver");
			}
		}
	}
}
