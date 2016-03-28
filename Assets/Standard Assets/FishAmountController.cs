using UnityEngine;
using System.Collections;

public class FishAmountController : MonoBehaviour {
	public int[] numFishPerSchool = {19, 20, 36, 37, 37, 37, 33, 34, 66, 46, 59, 53, 56, 59, 94, 83, 74, 100, 40};
	public float[] proportionChinook= {0.357f, 0.378f, 0.226f, 0.2009f, 0.1359f, 0.1157f, 0.14549f, 0.17797f, 0.0896f, 0.1738f, 0.2422f, 0.279f, 0.247f, 0.1972f, 0.093f, 0.08f, 0.07f, 0.06f, 0.15f};
	public int initialYear = 1975;
	public int finalYear = 1993;
	public int yearsFromStart = 0;
	public bool chinookEnabled = true;
	public bool otherEnabled = true;
	public GameObject schoolToCopy;
	public string[] timeControlKeys = { "z", "x", "c", "v" };
	private GameObject school = null;
	private WaveState previousState = null;
	private int secondsPerWave = 20;
	private int secondsUntilNextWave;
	public int waveNum = 0;
	// Use this for initialization
	void Start () {
		SpawnSchool ();
		secondsUntilNextWave = secondsPerWave;
		InvokeRepeating ("DecrementTime", 0, 1);
	}
	void Update() {
		if (Input.GetKeyDown (timeControlKeys[0])) {
			chinookEnabled = !chinookEnabled;
		}
		if (Input.GetKeyDown (timeControlKeys[1])) {
			otherEnabled = !otherEnabled;
		}
		if (Input.GetKeyDown (timeControlKeys[2])) {
			ChangeYear (-1);
		}
		if (Input.GetKeyDown (timeControlKeys[3])) {
			ChangeYear (1);
		}
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
		return string.Format("{0}{1}{2}\n{3}s", GetCurrentYear(), chinookEnabled ? ", CHINOOK" : "", otherEnabled ? ", OTHER" : "", secondsUntilNextWave);
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