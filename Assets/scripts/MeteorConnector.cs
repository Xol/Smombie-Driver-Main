using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorConnector : MonoBehaviour {
	
	static string room_id;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start() {
		StartCoroutine (MeteorCoroutine ());
	}
		

	IEnumerator MeteorCoroutine() {
		// connect to meteor
		yield return Meteor.Connection.Connect ("ws://localhost:3000/websocket");

		// Create a collections
		var rooms = new Meteor.Collection<RoomDocumentType> ("rooms");
		var points = new Meteor.Collection<PointDocumentType> ("points");
		var notifications = new Meteor.Collection<NotificationstDocumentType> ("notifications");

		// Create a room when game starts
		var methodCall = Meteor.Method<string>.Call ("createRoom");
		yield return (Coroutine)methodCall;
		room_id = methodCall.Response;
		Debug.Log ("Room " + room_id + " created.");
		GameObject.Find ("RoomKey").GetComponent<TextMesh> ().text = room_id;

		// Room to syncronize app and desktop
		var room_observer = rooms.Find ().Observe (
			added: (string id, RoomDocumentType document) => {
				//Debug.Log(string.Format("Document added: [_id={0}]", document._id));
			},
			changed: (string id, RoomDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id && document.app_connected) {
					GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = Color.green;
					Debug.Log("App connected");
				}
			}
		);
		// Points made in the app
		var points_observer = points.Find ().Observe (
			added: (string id, PointDocumentType document) => {
				if (document.room_id == room_id) {
					Debug.Log("Points: " + document.points);
				}
			},
			changed: (string id, PointDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id) {
					Debug.Log("Points: " + document.points);
				}
			}
		);
		// Notifications sent between app and desktop
		var notifications_observer = notifications.Find ().Observe (
			added: (string id, NotificationstDocumentType document) => {
				if (document.room_id == room_id) {
					Debug.Log("New notification: " + document.notification_type);
				}
			}
		);
	}

}

public class RoomDocumentType : Meteor.MongoDocument {
	public string room_id;
	public bool app_connected;
}

public class PointDocumentType : Meteor.MongoDocument {
	public string room_id;
	public int points;
}

public class NotificationstDocumentType : Meteor.MongoDocument {
	public string room_id;
	public string notification_type;
}