/**
 * Now handled in FishAmountController
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeController : MonoBehaviour {
	private FishAmountController control;
	private TextMesh[] text;
	private Color originalArrowColor;
	private Color originalTextColor;
	private Color highlightColor;
	private Color errorColor;

	private int selectedYear;
	private bool chinookEnabled;
	private bool otherEnabled;

	Dictionary<string,int> typeToTextPosition = new Dictionary<string,int>();

	// Use this for initialization
	void Start () {
		chinookEnabled = true;
		otherEnabled = true;
		control = (FishAmountController) FindObjectOfType(typeof(FishAmountController));
		selectedYear = control.GetCurrentYear ();
		text = GetComponentsInChildren<TextMesh> ();
		initializeDictionary ();
		originalArrowColor = text [typeToTextPosition["LeftArrow"]].color;
		originalTextColor = text [typeToTextPosition["Chinook"]].color;
		highlightColor = Color.green;
		errorColor = Color.red;
	}

	private void initializeDictionary() {
		typeToTextPosition.Add ("Year", 0);
		typeToTextPosition.Add ("RightArrow", 1);
		typeToTextPosition.Add ("LeftArrow", 2);
		typeToTextPosition.Add ("Chinook", 3);
		typeToTextPosition.Add ("Other", 4);
		typeToTextPosition.Add ("Set", 5);
	}

	// Update is called once per frame
	void Update () {
		text[0].text = string.Format("YEAR: {0}", selectedYear);
		text[3].text = string.Format("CHINOOK: {0}", chinookEnabled);
		text[4].text = string.Format("OTHER: {0}", otherEnabled);
	}

	public void IncreaseSelectedYear(int amount) {
		int result = selectedYear + amount;
		if (result <= control.finalYear && result >= control.initialYear) {
			selectedYear += amount;
		}
		if (result == control.finalYear) {
			text [typeToTextPosition["RightArrow"]].color = errorColor;
		}
		if (result == control.initialYear) {
			text [typeToTextPosition["LeftArrow"]].color = errorColor;
		}
	}

	public void Highlight(string type) {
		Color colorToUse = highlightColor;
		if (isError (type)) {
			colorToUse = errorColor;
		}
		text[typeToTextPosition[type]].color = colorToUse;
	}

	private bool isError(string type) {
		return ((type == "RightArrow" && selectedYear + 1 > control.finalYear) ||
		(type == "LeftArrow" && selectedYear - 1 < control.initialYear));
	}

	public void Delight(string type) {
		if (type == "RightArrow" || type == "LeftArrow") {
			text [typeToTextPosition[type]].color = originalArrowColor;
		} else {
			text [typeToTextPosition[type]].color = originalTextColor;
		}
	}

	public void ToggleChinook() {
		chinookEnabled = !chinookEnabled;
	}

	public void ToggleOther() {
		otherEnabled = !otherEnabled;
	}

	public void PushValues() {
		control.yearsFromStart = selectedYear - control.initialYear;
		control.chinookEnabled = chinookEnabled;
		control.otherEnabled = otherEnabled;
	}
}
**/