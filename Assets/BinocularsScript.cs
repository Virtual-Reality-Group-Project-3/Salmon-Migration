using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BinocularsScript : MonoBehaviour {
	public GameObject binoController;
	public GameObject binoModel;
	public GameObject player = null;
	private bool havePlayer=false;


	private bool inBinoView = false;

	// Use this for initialization
	void Start () {
	
	}
	void toggleBinoView(bool toggle) {
		binoController.SetActive ( toggle);
		binoModel.SetActive (!toggle);
		player.GetComponent<TogglePlayer> ().toggle (!toggle);
		inBinoView = toggle;

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
				toggleBinoView (!inBinoView);
			}
		}

	}
}
