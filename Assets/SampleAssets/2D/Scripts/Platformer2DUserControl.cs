using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
	//[RequireComponent(typeof (BehaviourScript))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
		private bool jump;

		public Texture2D tex;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
			tex = new Texture2D(640, 480, TextureFormat.RGB24, false);
        }

        private void Update()
        {
			if (!jump) {
				// Read the jump input in Update so button presses aren't missed.
				jump = CrossPlatformInputManager.GetButtonDown ("Jump");
			}

			StartCoroutine (captureScreen());
			/*
			// Read screen contents into the texture
			tex.ReadPixels(new Rect(0, 0, 640, 480), 0, 0);

			tex.Apply ();
			
			//byte[] bytes = tex.EncodeToPNG();
			//System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen1.png", bytes);
			
			Color[] bv = tex.GetPixels();


			Color test = new Color (0.247F, 0.710F, 0.851F, 1.000F);
			if (test.ToString () == bv.GetValue (86600).ToString ()) {
				character.Move(1,false,true);
				//Debug.Log ("HEY HEY HEY HEY HEY HEY HEY HEY!!!!!");
			}

			//Debug.Log (test.ToString() + "  Bnana");
			//Debug.Log (bv.GetValue (86500).ToString());
			*/

        }


		private IEnumerator captureScreen(){
			yield return new WaitForEndOfFrame();

			// Read screen contents into the texture
			tex.ReadPixels(new Rect(0, 0, 640, 480), 0, 0);
			
			tex.Apply ();
			
			byte[] bytes = tex.EncodeToPNG();
			System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen1.png", bytes);
			
			Color[] bv = tex.GetPixels();
			
			
			Color test = new Color (0.247F, 0.710F, 0.851F, 1.000F);
			if (test.ToString () == bv.GetValue (86600).ToString ()) {
				character.Move(1,false,true);
				//Debug.Log ("HEY HEY HEY HEY HEY HEY HEY HEY!!!!!");
			}



			//Debug.Log (test.ToString() + "  Bnana");
			//Debug.Log (bv.GetValue (86500).ToString());
		}


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
			//float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.



			character.Move(1, false, jump);
			jump = false;

        }

    }
}