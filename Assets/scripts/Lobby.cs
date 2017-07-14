using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour {
	
	static string room_id;

	void Start() {
		StartCoroutine (MeteorExample ());
	}
		

	IEnumerator MeteorExample() {
			yield return Meteor.Connection.Connect ("ws://localhost:3000/websocket");

		// Create a collection
		var collection = new Meteor.Collection<RoomDocumentType> ("rooms");

		// Add some handlers with the new observer syntax
		var observer = collection.Find ().Observe (
			added: (string id, RoomDocumentType document) => {
				Debug.Log(string.Format("Document added: [_id={0}]", document._id));
			},
			changed: (string id, RoomDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id) {
					Debug.Log("App connected");
				}
			}
		);



		// Subscribe
		// var subscription = Meteor.Subscription.Subscribe ("subscriptionEndpointName", /*arguments*/ 1, 3, 4);
		// The convention to turn something into a connection is to cast it to a Coroutine
		// yield return (Coroutine)subscription;

		// Create a method call that returns a string
		var methodCall = Meteor.Method<string>.Call ("createRoom");
		// Execute the method. This will yield until all the database side effects have synced.
		yield return (Coroutine)methodCall;
		room_id = methodCall.Response;
		Debug.Log ("Room " + room_id + " created.");

		// Get the value returned by the method.
		// Debug.Log (string.Format ("Method response:\n{0}", methodCall.Response));
	}

}

public class RoomDocumentType : Meteor.MongoDocument {
	public string room_id;
	public bool app_connected;
}
