using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FOVTest : MonoBehaviour {

	// Use this for initialization
	public float FOV = 45;
	public float ZoomSpeed = 1;
	public int minFov = 22;
	public int maxFov = 90;
	private Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxis ("Vertical");
		FOV -= x * ZoomSpeed;
		FOV = Mathf.Min (maxFov, FOV);
		FOV = Mathf.Max (minFov, FOV);
		cam.fieldOfView = FOV;
		Vector3 positionTracking;
		//positionTracking = UnityEngine.VR.InputTracking.GetLocalPosition (UnityEngine.VR.VRNode.Head);
		//transform.localPosition = -positionTracking;
		//transform.localPosition += new Vector3 (0, .5f, 0);


	}

}
