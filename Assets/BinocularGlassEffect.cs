using UnityEngine;
using System.Collections;

public class BinocularGlassEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Texture2D BinocularTexture;
	void OnGUI() {
		//Debug.Log ("Called");
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), BinocularTexture);

	}
}
