using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Based off http://answers.unity3d.com/questions/624114/a-simple-ladder-in-c-or-js.html
public class LadderClimberC : MonoBehaviour {
	private Transform selfTransform;
    public float speed = 1;
	public bool disableGravityUponEnter = true;
	public float rotationSpeed = .8f;
	private bool isPlayingSplash = false;
	public bool splash = false;
	//Above two vars control how fast the fish bobs arounds in water in this stream;
	public HashSet<GameObject> salmonSet = new HashSet<GameObject> ();

	public bool invertDirection = false;

    public void Start() {
		
		selfTransform = this.GetComponent<Transform>();
    }
    public void OnTriggerEnter(Collider collider) {
		//Debug.Log ("Entered " + collider.gameObject.name + " Tagged with " + collider.gameObject.tag);
		if (collider.gameObject.CompareTag ("salmon")) {
			salmonSet.Add (collider.gameObject);
			if (!collider.gameObject.GetComponent<AudioSource>().isPlaying && !isPlayingSplash && splash && collider.gameObject.GetComponent<TimeVal>().time < 0 && CurrentSplashesPlaying.splashes < 0) {
				collider.gameObject.GetComponent<AudioSource> ().Play();
				collider.gameObject.GetComponent<TimeVal> ().time = 5f;
				CurrentSplashesPlaying.splashes = 2f; //Limit splashes to one per second
			}
			if (disableGravityUponEnter) {
				collider.gameObject.GetComponent<Rigidbody> ().useGravity = false;
			}
		}
    }

    public void OnTriggerExit(Collider collider) {
	if (collider.gameObject.CompareTag ("salmon")) {
		salmonSet.Remove (collider.gameObject);
			if (disableGravityUponEnter) {
				collider.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
    }

	private void rotateObjectIntoCurrent(GameObject obj) {
		Vector3 forward = selfTransform.forward;
		if (invertDirection) { 
			forward = -forward;
		}
		if (obj.transform.forward == forward) {
			return;
		}
		obj.transform.forward = obj.transform.forward + ((forward-obj.transform.forward) * Time.deltaTime*rotationSpeed);

	}

    public void Update() {
		//Debug.Log ("Self is " + selfTransform);
		Vector3 direction = selfTransform.forward;
		//Ok, we have direction, lets normalize it! Calc 3 stuff!
		//Oh wait, unity has this built in.
		direction.Normalize();
		Vector3 movementVector = direction * Time.deltaTime * speed;
		if (invertDirection) {
			movementVector = -movementVector;
		}
		isPlayingSplash = false;
		foreach ( GameObject obj in salmonSet ) {
			//isPlayingSplash = isPlayingSplash || obj.GetComponent<AudioSource> ().isPlaying;
			obj.GetComponent<TimeVal> ().time -= Time.deltaTime;
			if (disableGravityUponEnter) {
				obj.GetComponent<Rigidbody> ().useGravity = false;
			}
			//obj.transform.
			rotateObjectIntoCurrent(obj);
			//new
			obj.GetComponent<Rigidbody>().AddForce(movementVector*speed*3);


			//Move it forward here
			// obj.transform.Translate(movementVector,Space.World); //old
			//Debug.Log (selfTransform.forward + "    " + obj.transform.forward);


		}
    }
}
