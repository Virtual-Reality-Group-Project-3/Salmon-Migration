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
	public float volume_coin=1;
	public float volume_tick=1;




	private bool inBinoView = false;
	private AudioSource coinDropAudio; 
	private AudioSource tickingAudio;

	// Use this for initialization
	void Start () {
	

	}

	private AudioSource SetUpAudioSource(AudioClip clip)
	{
		// create the new audio source component on the game object and set up its properties
		AudioSource source = gameObject.AddComponent<AudioSource>();

		source.clip = clip;
		source.volume = 0;
		source.Play ();
		if (source == tickingAudio) {
			source.loop = true;
		} else {
			source.loop = false;
		}

		return source;
	}

	private void StartSound()
	{
		tickingAudio = SetUpAudioSource(tickingSound);
		coinDropAudio = SetUpAudioSource (coinDropSound);
	}

	void toggleBinoView(bool toggle) {
		StartSound ();
		binoController.SetActive ( toggle);
		binoModel.SetActive (!toggle);
		player.GetComponent<TogglePlayer> ().toggle (!toggle);
		inBinoView = toggle;

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

	private void StopSound()
	{
		//Destroy all audio sources on this object:
		foreach (var source in GetComponents<AudioSource>())
		{
			Destroy(source);
		}
	}


	// Update is called once per frame
	void Update () {
		


		if (havePlayer) {

			coinDropAudio.volume = volume_coin;
			tickingAudio.volume = volume_tick;

			if (CrossPlatformInputManager.GetButtonDown ("X Button") || Input.GetKeyDown ("f")) {
				toggleBinoView (!inBinoView);

			}

		} 

	}
}
