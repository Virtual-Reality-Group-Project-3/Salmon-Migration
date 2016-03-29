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

		this.GetComponent<CarUserControl> ().enabled = toggle;
		if (!toggle) {
			this.GetComponent<CarController> ().Move (0f, 0f, 0f, handBrakeVal);
		}
		this.GetComponent<CarController> ().enabled = toggle;
		this.GetComponent<CarAudio> ().enabled = toggle;



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
