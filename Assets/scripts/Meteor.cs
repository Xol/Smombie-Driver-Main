using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
	
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


		// Add some handlers
		var room_observer = rooms.Find ().Observe (
			added: (string id, RoomDocumentType document) => {
				Debug.Log(string.Format("Document added: [_id={0}]", document._id));
			},
			changed: (string id, RoomDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id) {
					GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = Color.green;
					Debug.Log("App connected");
				}
			}
		);

		var points_observer = points.Find ().Observe (
			added: (string id, PointDocumentType document) => {
				Debug.Log(string.Format("Document added: [_id={0}]", document._id));
			},
			changed: (string id, PointDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id) {
					Debug.Log("Points: " + document.points);
				}
			}
		);

		// Create a method call that returns a string
		var methodCall = Meteor.Method<string>.Call ("createRoom");

		// Execute the method. This will yield until all the database side effects have synced.
		yield return (Coroutine)methodCall;

		room_id = methodCall.Response;
		Debug.Log ("Room " + room_id + " created.");
		GameObject.Find ("RoomKey").GetComponent<TextMesh> ().text = room_id;

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