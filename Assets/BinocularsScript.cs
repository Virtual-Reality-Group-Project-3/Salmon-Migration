using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BinocularsScript : MonoBehaviour {
	public GameObject binoController;
	public GameObject binoModel;
	public GameObject player = null;
	private bool havePlayer=false;
	public AudioClip tickingSound;
	public AudioClip coinDropSound;




	private bool inBinoView = false;
	private AudioSource coinDropAudio; 
	private AudioSource tickingAudio;

	// Use this for initialization
	void Start () {
		StartSound ();
	}

	private AudioSource SetUpAudioSource(AudioClip clip)
	{
		// create the new audio source component on the game object and set up its properties
		AudioSource source = gameObject.AddComponent<AudioSource>();

		source.clip = clip;
		source.volume = 0;
		source.Play ();

		return source;
	}

	private void StartSound()
	{
		tickingAudio = SetUpAudioSource(tickingSound);
	}

	void toggleBinoView(bool toggle) {
		binoController.SetActive ( toggle);
		binoModel.SetActive (!toggle);
		player.GetComponent<TogglePlayer> ().toggle (!toggle);
		inBinoView = toggle;
		if (inBinoView) {
			tickingAudio.volume = 1;
		} else {
			tickingAudio.volume = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			havePlayer = true;
			player = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			havePlayer = false;
			player = null;
		}
	}


	// Update is called once per frame
	void Update () {
		if (havePlayer) {
			if (CrossPlatformInputManager.GetButtonDown ("X Button") || Input.GetKeyDown ("f")) {
				toggleBinoView (!inBinoView);
			}
		}
	}
}
