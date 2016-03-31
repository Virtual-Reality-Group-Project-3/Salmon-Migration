using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
		public AudioSource boatAudio;
		void Start() {
			boatAudio = GetComponent<AudioSource> ();
		}
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			v = Math.Max(0,v); //Stop reversing!
			if (Math.Abs(v) > 0 && !boatAudio.isPlaying) {
				boatAudio.Play ();
				boatAudio.volume = 1f;
				//Don't set volume to v inside this block!
			} else if (v == 0) {
				if (boatAudio.volume > .1f) {
					boatAudio.volume -= .1f;
				} else {
					boatAudio.Stop ();
				}
			}

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }




    }



}
