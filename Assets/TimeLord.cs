using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TimeLord : MonoBehaviour {
	public float timeScale = 1.0f;
	public float maxTimeScale = 6.0f;
	public float minTimeScale = 0.0f;
	public float incrementAmount = .5f;
	public bool timeChanged = false;
	// Use this for initialization
	private float previousDpad;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool increase = false;
		bool decrease = false;
		float currentDpad = CrossPlatformInputManager.GetAxis ("TimeScaleControls");
		if (currentDpad != previousDpad) {
			if (currentDpad == 1) {
				increase = true;
			}
			if (currentDpad == -1) {
				decrease = true;
			}
			previousDpad = currentDpad;
		}
		if (increase) {
			timeScale += incrementAmount;
			timeScale = Mathf.Min (maxTimeScale, timeScale);
			Time.timeScale = timeScale;

		}
		if (decrease) {
			timeScale -= incrementAmount;
			timeScale = Mathf.Max (minTimeScale, timeScale);
			Time.timeScale = timeScale;
		}
		timeChanged = (increase || decrease);
	}
}
