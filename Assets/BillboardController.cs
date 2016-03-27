using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BillboardController : MonoBehaviour {
	private FishAmountController fishControl;
	private CanvasRenderer cr;
	private Text t;
	public bool zoomable;
	// Use this for initialization
	void Start () {
		fishControl = (FishAmountController) FindObjectOfType(typeof(FishAmountController));
		t = GetComponentInChildren<Text> ();
		cr = GetComponentInChildren<CanvasRenderer> ();
		cr.SetAlpha (0);
	}
	
	// Update is called once per frame
	void Update () {
		bool flag = false;
		foreach (string s in fishControl.timeControlKeys) {
			if (Input.GetKeyDown (s)) {
				CancelInvoke ("FadeOut");
				cr.SetAlpha (1);
				flag = true;
				break;
			}
		}
		if (!flag) {
			Invoke ("FadeOut", 2);
		}
		if (zoomable) {
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, 20));
		}
		t.text = string.Format("CURRENT WAVE\n{0}\nNEXT WAVE\n{1}", fishControl.GetPreviousState(), fishControl.GetCurrentState());
	}
	private void FadeOut() {
		cr.SetAlpha (cr.GetAlpha() - 0.01f);
	}
}
