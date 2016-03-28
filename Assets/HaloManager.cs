using UnityEngine;
using System.Collections;

public class HaloManager : MonoBehaviour {
	public int waveNum;
	public GameObject controllerObject;
	public FishAmountController fishController;
	// Use this for initialization
	void Start () {
		controllerObject = GameObject.FindGameObjectWithTag ("fish controller");
		fishController = controllerObject.GetComponent<FishAmountController> ();
		waveNum = fishController.waveNum;

	}
	
	// Update is called once per frame
	void Update () {
		if ( fishController.waveNum - waveNum >= 2 ) {
			//disableHalo
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

		}
	}
}
