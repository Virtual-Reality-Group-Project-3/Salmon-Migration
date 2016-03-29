using UnityEngine;
using System.Collections;

public class SpeedBump : MonoBehaviour {
	public float reduceBy = .5f;
	public float reduceIfGreaterThan = 10f;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider collide) {
		if (collide.gameObject.CompareTag ("salmon") && collide.gameObject.GetComponent<Rigidbody>().velocity.magnitude > reduceIfGreaterThan) {
			collide.gameObject.GetComponent<Rigidbody> ().velocity = collide.gameObject.GetComponent<Rigidbody> ().velocity * reduceBy;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
