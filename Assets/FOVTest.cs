using UnityEngine;
using System.Collections;

public class FOVTest : MonoBehaviour {

	// Use this for initialization
	public int setFovTo = 40;
	public Camera cam;
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		cam.fieldOfView = setFovTo;

	}
}
