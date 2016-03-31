using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BillboardController : MonoBehaviour {
	private FishAmountController fishControl;
	private TimeLord timeLord;
	private CanvasRenderer cr;
	private Text t;
	public bool alwaysVisible;
	public bool isLarge;
	// Use this for initialization
	void Start () {
		fishControl = (FishAmountController) FindObjectOfType(typeof(FishAmountController));
		timeLord = (TimeLord) FindObjectOfType(typeof(TimeLord));
		t = GetComponentInChildren<Text> ();
		cr = GetComponentInChildren<CanvasRenderer> ();
		if (!alwaysVisible) {
			cr.SetAlpha (0);
		}
	}

	// Update is called once per frame
	void Update () {
		if (isLarge) {
			if (Camera.main == null) {
				fishControl.billboardVisible = false;
			} else {
				Vector3 screenPoint = Camera.main.WorldToViewportPoint (this.transform.position);
				if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) {
					fishControl.billboardVisible = true;
				} else {
					fishControl.billboardVisible = false;
				}
			}
		}
		if (!alwaysVisible) {
			if (!fishControl.billboardVisible && (fishControl.displayHUD || timeLord.timeChanged)) {
				CancelInvoke ("FadeOut");
				cr.SetAlpha (1);
			} else {
				Invoke ("FadeOut", 2);
			}
		}
		t.text = string.Format("CURRENT WAVE\n{0}\nNEXT WAVE\n{1}, {2}x speed", fishControl.GetPreviousState(), fishControl.GetCurrentState(), timeLord.timeScale);
	}
	private void FadeOut() {
		cr.SetAlpha (cr.GetAlpha() - 0.01f);
	}
}
