using UnityEngine;
using System.Collections;

public class ReplacementScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	public void OnTriggerEnter(Collider collider) {
		Transform fishTransform; 
		if (collider.gameObject.CompareTag ("fish from school")) {
			Debug.Log ("Destroying! " + collider.gameObject.name);
			fishTransform = collider.gameObject.transform;
			Destroy (collider.gameObject);

			GameObject newFish = Instantiate(collider.gameObject.GetComponent<GetLadderClimber> ().getLadderCLimber ());
			Debug.Log (newFish.name);
			newFish.transform.position = fishTransform.position;
			newFish.transform.rotation = fishTransform.rotation;
			newFish.transform.localScale = fishTransform.localScale;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
