using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class ToggleCar : MonoBehaviour {
	public GameObject camera;
	public float handBrakeVal = 0f;
	// Use this for initialization
	void Start () {
	
	}
	public void toggle(bool toggle) {
		camera.SetActive (toggle);
		if (!toggle) {
			this.GetComponent<CarController> ().Move (0f, 0f, 0f, handBrakeVal);
			this.GetComponent<CarUserControl> ().boatAudio.Stop ();
		}
		this.GetComponent<CarUserControl> ().enabled = toggle;

		//this.GetComponent<CarController> ().enabled = toggle;

		//this.GetComponent<CarAudio> ().enabled = toggle;
		//Probably best to leave these two on, only need tod isable the controller!
		if (toggle) {
			this.GetComponent<CarController> ().Move (0f, 0f, 0f,0f);
		}




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
