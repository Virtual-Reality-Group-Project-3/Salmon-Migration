using UnityEngine;
using System.Collections;

public class JumpWhenHitFloor : MonoBehaviour {
	public float jumpMagnitude = 1;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if ( collision.gameObject.CompareTag("ladderstep") ) {
			this.GetComponent<Rigidbody> ().AddForce(0,jumpMagnitude,0);
		}
	}
	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.CompareTag ("ladderstep")) {
			this.GetComponent<Rigidbody> ().AddForce (0, jumpMagnitude, 0);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
