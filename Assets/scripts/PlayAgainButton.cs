using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour {

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().ResetPoints());
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector> ().NotifyMeteor (NotificationTypeEnum.GAME_START));
			SceneManager.LoadScene("smombie-driver");
		}
	}
}
