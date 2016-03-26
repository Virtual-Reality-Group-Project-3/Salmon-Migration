using UnityEngine;
using System.Collections;

public class BillboardController : MonoBehaviour {
	private FishAmountController fishControl;
	private TextMesh text;
	// Use this for initialization
	void Start () {
		fishControl = (FishAmountController) FindObjectOfType(typeof(FishAmountController));
		text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = string.Format("CURRENT WAVE\n{0}\nNEXT WAVE\n{1}", fishControl.GetPreviousState(), fishControl.GetCurrentState());
	}
}
