using UnityEngine;
using System.Collections;

public class MakePlayerChildWhileInside : MonoBehaviour {
	public Transform formerParent = null;
	public GameObject playerContainer;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider collide) {
		if (collide.gameObject.CompareTag ("Player")) {
			playerContainer.transform.parent = this.transform;
		}
	}
	void OnTriggerExit(Collider collide) {
		if (collide.gameObject.CompareTag ("Player")) {

			playerContainer.transform.parent = formerParent;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
