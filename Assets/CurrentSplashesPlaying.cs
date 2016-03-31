using UnityEngine;
using System.Collections;

public class CurrentSplashesPlaying : MonoBehaviour {
	public static float splashes = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		splashes -= Time.deltaTime;
	}
}
