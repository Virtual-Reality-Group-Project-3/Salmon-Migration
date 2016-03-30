using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DownScript : MonoBehaviour {
	private HashSet<GameObject> ignoreCollisions = new HashSet<GameObject> ();
	private List<GameObject> removeList = new List<GameObject> ();
	private Transform selfTransform;
	private Collider selfCollider;

	//Force fish which have gotten out of bounds nad gone above the ceiling to get back down....
	//Essentially, if they are above the "roof", have them fall back down, but then renable the collider for them...

	public void Start() {
		selfTransform = this.GetComponent<Transform>();
		//Debug.Log( "My position is " + selfTransform.position + "   and local is " + selfTransform.position);
		selfCollider = GetComponent<Collider> ();
		removeList.Clear ();
	}
	public void OnCollisionEnter(Collision collider) {
		//Debug.Log ("Entered " + collider.gameObject.name + " Tagged with " + collider.gameObject.tag);
		if (collider.gameObject.CompareTag ("salmon")) {
			//Debug.Log ("DOWN!");
			if ((collider.gameObject.transform.position.y > selfTransform.position.y)) {

				Physics.IgnoreCollision (collider.collider,selfCollider, true);
				ignoreCollisions.Add (collider.gameObject);

			}
		}

	}


	public void Update() {
		foreach (GameObject obj in ignoreCollisions) {
			if (!obj) {
				removeList.Add (obj);
				continue;
				//Continue on if null, and remove
			}
			if (obj.transform.position.y < selfTransform.position.y) {
				Physics.IgnoreCollision (obj.GetComponent<Collider>(), selfCollider, false);
				removeList.Add (obj);
				//Debug.Log ("Removing " + obj.name);
			}
		}
		foreach (GameObject obj in removeList) {
			ignoreCollisions.Remove (obj);
		}
		removeList.Clear ();
	}


}
//if (collider.gameObject.transform.position.y > selfTransform.position.y) {
//	collider.gameObject.transform.Translate (new Vector3 (0, -.3f, 0), Space.World);
//}