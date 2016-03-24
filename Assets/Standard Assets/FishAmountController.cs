using UnityEngine;
using System.Collections;

public class FishAmountController : MonoBehaviour {
	public int[] numFishPerSchool = {100, 80, 60, 80};
	public float[] proportionChinook= {0.9f, 0.1f, 0.3f, 0.5f};
	public int yearsFromStart = 0;
	public GameObject schoolToCopy;
	private GameObject school = null;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnSchool", 0f, 20.0f);
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
		school.transform.position = schoolToCopy.transform.position;
		yearsFromStart++;
	}
}
