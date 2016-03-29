using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FishAmountController : MonoBehaviour {
	public int[] numFishPerSchool = {19, 20, 36, 37, 37, 37, 33, 34, 66, 46, 59, 53, 56, 59, 94, 83, 74, 100, 40};
	public float[] proportionChinook= {0.357f, 0.378f, 0.226f, 0.2009f, 0.1359f, 0.1157f, 0.14549f, 0.17797f, 0.0896f, 0.1738f, 0.2422f, 0.279f, 0.247f, 0.1972f, 0.093f, 0.08f, 0.07f, 0.06f, 0.15f};
	public int initialYear = 1975;
	public int finalYear = 1993;
	public int yearsFromStart = 0;
	public bool chinookEnabled = true;
	public bool otherEnabled = true;
	public bool displayHUD = false;
	public GameObject schoolToCopy;
	private GameObject school = null;
	private WaveState previousState = null;
	private int secondsPerWave = 30;
	private int secondsUntilNextWave;
	public int waveNum = 0;
	// Use this for initialization
	void Start () {
		previousState = new WaveState ();
		secondsUntilNextWave = secondsPerWave;
		InvokeRepeating ("DecrementTime", 0, 1);
	}
	void Update() {
		bool changingValues = false;
		if (Input.GetKeyDown ("z") || CrossPlatformInputManager.GetButtonDown ("Toggle Chinook")) {
			chinookEnabled = !chinookEnabled;
			changingValues = true;
		}
		if (Input.GetKeyDown ("x") || CrossPlatformInputManager.GetButtonDown ("Toggle Other")) {
			otherEnabled = !otherEnabled;
			changingValues = true;
		}
		if (Input.GetKeyDown ("c") || CrossPlatformInputManager.GetButtonDown ("Time Backward")) {
			ChangeYear (-1);
			changingValues = true;
		}
		if (Input.GetKeyDown ("v") || CrossPlatformInputManager.GetButtonDown ("Time Forward") ) {
			ChangeYear (1);
			changingValues = true;
		}
		displayHUD = changingValues;
	}
	private void SpawnSchool() {
		++waveNum;
		Debug.Log ("Making school");
		if (school != null) {
			Destroy (school);
		}
		school = Instantiate (schoolToCopy);
		previousState = new WaveState (GetCurrentYear (), chinookEnabled, otherEnabled);
	}

	private void DecrementTime() {
		if (--secondsUntilNextWave == 0) {
			SpawnSchool ();
			secondsUntilNextWave = secondsPerWave;
		}
	}
	public void ChangeYear(int amount) {
		int result = GetCurrentYear() + amount;
		if (result <= finalYear && result >= initialYear) {
			yearsFromStart += amount;
		} else {
			// play error sound
		}
	}

	public int GetCurrentYear() {
		return initialYear + yearsFromStart;
	}

	public string GetPreviousState() {
		return previousState.ToString ();
	}

	public string GetCurrentState() {
		return string.Format("{0}{1}{2}\n{3}s", GetCurrentYear(), chinookEnabled ? " CHINOOK" : "                 ", otherEnabled ? " OTHER" : "", secondsUntilNextWave);
	}
}

class WaveState {
	private int year;
	private bool chinookEnabled;
	private bool otherEnabled;
	private bool enabled;

	public WaveState() {
		this.enabled = false;
	}

	public WaveState(int year, bool chinookEnabled, bool otherEnabled) {
		this.year = year;
		this.chinookEnabled = chinookEnabled;
		this.otherEnabled = otherEnabled;
		this.enabled = true;
	}
	public override string ToString() {
		if (enabled) {
			return string.Format ("{0}{1}{2}", year, chinookEnabled ? " CHINOOK" : "                 ", otherEnabled ? " OTHER" : "");
		} else {
			return "N/A";
		}
	}
}