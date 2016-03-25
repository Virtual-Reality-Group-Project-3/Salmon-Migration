using UnityEngine;
using System.Collections;

public class ReplacementScript : MonoBehaviour {
	public int ratePerSecond = 5;
	private float timeCount;
	private int spawned;
	// Use this for initialization
	void Start () {
	
	}
	public void OnTriggerEnter(Collider collider) {
		if (timeCount > 1) { 
			timeCount = 0; 
			spawned = 0;
		}
		if (spawned >= ratePerSecond) {
			return;
		}
		++spawned;
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
			timeCount += Time.deltaTime;
	}
}
