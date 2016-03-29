using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EnterCar : MonoBehaviour {

	private GameObject player = null;
	private bool havePlayer=false;
	public GameObject car;


	private bool inCarView = false;

	// Use this for initialization
	void Start () {

	}
	void toggleCarMode(bool toggle) {
		player.GetComponent<TogglePlayer> ().toggle (!toggle);
		car.GetComponent<ToggleCar> ().toggle (toggle);
		inCarView = toggle;

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