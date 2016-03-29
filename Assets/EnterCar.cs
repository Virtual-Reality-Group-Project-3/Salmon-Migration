using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EnterCar : MonoBehaviour {

	private GameObject player = null;
	private bool havePlayer=false;
	public GameObject car;
	public GameObject cockpitRearWall;
	public float maxExitSpeed;
	public GameObject OriginalSpot;


	private bool inCarView = false;

	// Use this for initialization
	void Start () {

	}
	void toggleCarMode(bool toggle) {

		player.GetComponent<TogglePlayer> ().toggle (!toggle);
		car.GetComponent<ToggleCar> ().toggle (toggle);
		cockpitRearWall.SetActive (toggle);


		Vector3 newVelocity = car.GetComponent<Rigidbody> ().velocity;
		if (!toggle && ((newVelocity.normalized * maxExitSpeed).magnitude < newVelocity.magnitude)) { //If we are leaving the car, slow it down.
			Debug.Log("Was ran");
			car.GetComponent<Rigidbody> ().velocity = newVelocity.normalized * maxExitSpeed;
			Debug.Log (car.GetComponent<Rigidbody> ().velocity);
		}
		inCarView = toggle;
		Debug.Log ("Inside? " + OriginalSpot.GetComponent<ResetToOriginalSpot>().inside + " ");
		if (!inCarView && OriginalSpot.GetComponent<ResetToOriginalSpot> ().inside) {
			Debug.Log ("Was ran");
			OriginalSpot.GetComponent<ResetToOriginalSpot> ().reset (car.transform);
			OriginalSpot.GetComponent<ResetToOriginalSpot> ().rearWall.SetActive (false);
		} else {
			OriginalSpot.GetComponent<ResetToOriginalSpot> ().rearWall.SetActive (true);
		}

	

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			havePlayer = true;
			player = other.gameObject;

		}
	}
	void OnTriggerExit(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			havePlayer = false;
			player = null;

		}
	}


	// Update is called once per frame
	void Update () {
		if (havePlayer) {
			if (CrossPlatformInputManager.GetButtonDown ("X Button") || Input.GetKeyDown ("f")) {
				toggleCarMode (!inCarView);
			}
		}

	}

}