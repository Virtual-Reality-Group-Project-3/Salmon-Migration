using UnityEngine;
using System.Collections;

public class ResetToOriginalSpot : MonoBehaviour {
	public Transform original;
	private Vector3 rotation;
	private Vector3 position;
	private Vector3 scale;
	// Use this for initialization
	void Start () {
		scale = original.localScale;
		position = original.position;
		rotation = original.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
