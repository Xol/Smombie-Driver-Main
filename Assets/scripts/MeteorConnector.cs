using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class that handles connection and communication to meteor backend and app
 */
public class MeteorConnector : MonoBehaviour {

	const string SERVER_IP = "ws://localhost:3000/websocket";
	
	public static string room_id;

	Meteor.Collection<RoomDocumentType> rooms;
	Meteor.Collection<PointDocumentType> points;
	Meteor.Collection<NotificationstDocumentType> notifications;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start() {
		StartCoroutine (initialize ());
		SceneManager.LoadScene("Lobby"); 
		StartCoroutine (CreateRoom ());
	}

	/**
	 * Send notifications to meteor server 
	 **/
	public IEnumerator NotifyMeteor(NotificationTypeEnum notification_type) {
		Debug.Log (room_id + ", " + notification_type);
		var methodCall = Meteor.Method<string>.Call ("notify", room_id, notification_type, false);
		yield return (Coroutine)methodCall;
	}

	public IEnumerator ModifyPoints(int amount) {
		var methodCall = Meteor.Method<string>.Call ("setPoints", room_id, amount);
		yield return (Coroutine)methodCall;
	}

	public IEnumerator ResetPoints() {
		var methodCall = Meteor.Method<string>.Call ("resetPoints", room_id);
		yield return (Coroutine)methodCall;
	}

	/**
	 * Initialize observers for meteor collections
	 **/
	private void initializeObservers() {
		// Room to syncronize app and desktop
		var room_observer = rooms.Find ().Observe (
			added: (string id, RoomDocumentType document) => {
				//Debug.Log(string.Format("Document added: [_id={0}]", document._id));
			},
			changed: (string id, RoomDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id && document.app_connected) {
					GameObject.Find ("Main Camera").GetComponent<Camera> ().backgroundColor = Color.green;
					Debug.Log ("App connected");
					GameObject.Find("Countdown").GetComponent<LobbyCountdown>().activateCountdown();

				}
			}
		);
		// Points made in the app
		var points_observer = points.Find ().Observe (
			added: (string id, PointDocumentType document) => {
				if (document.room_id == room_id) {
					GameObject gameUI = GameObject.Find("GameUI");
					if (gameUI) {
						gameUI.GetComponent<UIController>().setPoints(document.points + "");
					}
					Debug.Log ("Points: " + document.points);
				}
			},
			changed: (string id, PointDocumentType document, IDictionary changes, string[] deletions) => {
				if (document.room_id == room_id) {
					GameObject gameUI = GameObject.Find("GameUI");
					if (gameUI) {
						gameUI.GetComponent<UIController>().setPoints(document.points + "");
					}
					Debug.Log ("Points: " + document.points);
				}
			}
		);
		// Notifications sent between app and desktop
		var notifications_observer = notifications.Find ().Observe (
			added: (string id, NotificationstDocumentType document) => {
				if (document.room_id == room_id) {
					Debug.Log ("New notification: " + document.notification_type);
				}
			}
		);
	}

	/**
	 * Initialize meteor connection and create collections on client
	 **/
	private IEnumerator initialize() {
		// connect to meteor
		yield return Meteor.Connection.Connect (SERVER_IP);
		// Create a collections
		rooms = new Meteor.Collection<RoomDocumentType> ("rooms");
		points = new Meteor.Collection<PointDocumentType> ("points");
		notifications = new Meteor.Collection<NotificationstDocumentType> ("notifications");

		initializeObservers ();
	}

	/**
	 * Create room to syncronize app and desktop
	 **/
	public IEnumerator CreateRoom() {
		// Create a room when game starts
		var methodCall = Meteor.Method<string>.Call ("createRoom");
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

public class NotificationstDocumentType : Meteor.MongoDocument {
	public string room_id;
	public string notification_type;
	public bool solved;
}