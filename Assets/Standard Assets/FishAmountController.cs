using UnityEngine;
using System.Collections;

public class FishAmountController : MonoBehaviour {
	public int[] numFishPerSchool = {100, 80, 60, 80};
	public float[] proportionChinook= {0.9f, 0.1f, 0.3f, 0.5f};
	public int initialYear = 1970;
	public int finalYear = 1975;
	public int yearsFromStart = 0;
	public bool chinookEnabled = true;
	public bool otherEnabled = true;
	public GameObject schoolToCopy;
	private GameObject school = null;
	private WaveState previousState = null;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnSchool", 0f, 40.0f);
	}
	// Update is called once per frame
	void Update () {
	
	}
	private void SpawnSchool() {
		Debug.Log ("Making school");
		if (school != null) {
			Destroy (school);
		}
		school = Instantiate (schoolToCopy);
		previousState = new WaveState (GetCurrentYear (), chinookEnabled, otherEnabled);
	}
	public int GetCurrentYear() {
		return initialYear + yearsFromStart;
	}
	public string GetPreviousState() {
		return previousState.ToString ();
	}
	public string GetCurrentState() {
		return string.Format("{0}{1}{2}", GetCurrentYear(), chinookEnabled ? ", CHINOOK" : "", otherEnabled ? ", OTHER" : "");
	}
}

class WaveState {
	private int year;
	private bool chinookEnabled;
	private bool otherEnabled;

	public WaveState(int year, bool chinookEnabled, bool otherEnabled) {
		this.year = year;
		this.chinookEnabled = chinookEnabled;
		this.otherEnabled = otherEnabled;
	}
	public override string ToString() {
		return string.Format("{0}{1}{2}", year, chinookEnabled ? ", CHINOOK" : "", otherEnabled ? ", OTHER" : "");
	}
}