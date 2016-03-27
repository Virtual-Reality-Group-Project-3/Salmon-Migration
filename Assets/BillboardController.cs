using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BillboardController : MonoBehaviour {
	private FishAmountController fishControl;
	private TimeLord timeLord;
	private CanvasRenderer cr;
	private Text t;
	public bool zoomable;
	public bool alwaysVisible;
	// Use this for initialization
	void Start () {
		fishControl = (FishAmountController) FindObjectOfType(typeof(FishAmountController));
		timeLord = (TimeLord) FindObjectOfType(typeof(TimeLord));
		t = GetComponentInChildren<Text> ();
		cr = GetComponentInChildren<CanvasRenderer> ();
		if (!alwaysVisible) {
			cr.SetAlpha (0);
		}
		if (zoomable) {
			Debug.Log ("Zoomable text not supported");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!alwaysVisible) {
			if (fishControl.displayHUD || timeLord.timeChanged) {
				CancelInvoke ("FadeOut");
				cr.SetAlpha (1);
			} else {
				Invoke ("FadeOut", 2);
			}
		}
		/**
		if (zoomable) {
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, 20));
		}
		**/
		t.text = string.Format("CURRENT WAVE\n{0}\nNEXT WAVE\n{1}, {2}x", fishControl.GetPreviousState(), fishControl.GetCurrentState(), timeLord.timeScale);
	}
	private void FadeOut() {
		cr.SetAlpha (cr.GetAlpha() - 0.01f);
	}
}
