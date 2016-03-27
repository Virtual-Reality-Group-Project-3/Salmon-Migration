using UnityEngine;
using System.Collections;

public class ClampHorizontally : MonoBehaviour {


	public GameObject Camera01;
	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationV;
	public float yRotationV;

	public float lookSmoothDamp = 0.1f;

	//Init
	void Start()
	{

	}    
	//FixedUpdate
	//Clamp Horizontally
	//http://answers.unity3d.com/questions/1035682/how-to-clamp-horizontal-rotation-of-the-camera.html
	void FixedUpdate()
	{
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;

		xRotation = Mathf.Clamp(xRotation, -90, 90);
		yRotation = Mathf.Clamp(yRotation, -90,90);

		currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
		currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

		transform.rotation = Quaternion.Euler(0, currentYRotation, currentXRotation);       
	}
}

