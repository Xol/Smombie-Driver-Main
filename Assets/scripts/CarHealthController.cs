using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		GameObject.Find ("health").GetComponent<TextMesh> ().text = health + "";
		if (health == 0) {
			StartCoroutine(GameObject.Find("__Meteor").GetComponent<MeteorConnector>().NotifyMeteor(NotificationTypeEnum.GAME_OVER));
		}
	}
}
