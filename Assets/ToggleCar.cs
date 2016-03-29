using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class ToggleCar : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	public void toggle(bool toggle) {
		camera.SetActive (toggle);
		this.GetComponent<CarAudio> ().enabled = toggle;
		this.GetComponent<CarController> ().enabled = toggle;
		this.GetComponent<CarUserControl> ().enabled = toggle;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
