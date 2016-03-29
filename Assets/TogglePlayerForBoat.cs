using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class TogglePlayerForBoat : MonoBehaviour {
	public GameObject camera;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void toggle(bool toggle) {
		this.GetComponent<RigidbodyFirstPersonController> ().enabled = toggle;
		camera.SetActive ( toggle);
	}
}
