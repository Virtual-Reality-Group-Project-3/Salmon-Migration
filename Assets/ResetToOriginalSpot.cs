using UnityEngine;
using System.Collections;

public class ResetToOriginalSpot : MonoBehaviour {
	public Transform original;
	private Quaternion rotation;
	private Vector3 position;
	//private Vector3 scale;
	public bool inside = false;
	public GameObject rearWall;

	// Use this for initialization
	void Start () {
		//scale = original.localScale;
		position = original.localPosition;
		rotation = original.localRotation;
	}
	void OnTriggerEnter(Collider collide) {
		if (collide.gameObject.CompareTag ("Interactive Car")) {
			inside = true;
		}
	}
	void OnTriggerExit(Collider collide) {
		if (collide.gameObject.CompareTag ("Interactive Car")) {
			inside = false;
		}
	}
	public void reset(Transform t) {
		t.localPosition = position;
		//t.localScale = scale;
		t.localRotation = rotation;
		t.gameObject.GetComponent<Rigidbody> ().velocity *= 0;
		t.gameObject.GetComponent<Rigidbody> ().angularVelocity *= 0;
	}


}

