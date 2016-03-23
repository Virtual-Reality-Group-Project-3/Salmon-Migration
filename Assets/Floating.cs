using UnityEngine;
using System.Collections;
//Adapted from http://answers.unity3d.com/questions/59934/how-to-an-object-floating-up-and-down.html
public class Floating : MonoBehaviour {
	private float y0;
	public float amplitude = 1f;
	public float speed = .25f;
	// Use this for initialization
	void Start () {
		y0=transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate( new Vector3(transform.position.x,y0+amplitude*Mathf.Sin(speed*Time.time),transform.position.z) );
	}
}