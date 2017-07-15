using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStartButton : MonoBehaviour {

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().ResetPoints());
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector> ().NotifyMeteor (NotificationTypeEnum.GAME_END));
			SceneManager.LoadScene("Lobby");
			Debug.Log ("Lobby");
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector> ().CreateRoom ());

		}
	}
}
