using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{
	
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class NeuralNetwork : MonoBehaviour
	{
		private PlatformerCharacter2D character;
		public Transform player;
		private int count = 0;
		
		private void Awake()
		{
			character = GetComponent<PlatformerCharacter2D>();

		}
		
		private void Update()
		{	
			Texture2D tex = new Texture2D(50, 25, TextureFormat.RGB24, false);
			
			// Read screen contents into the texture
			tex.ReadPixels(new Rect(90, 123, 50, 25), 0, 0);
			tex.Apply ();
			
			//byte[] bytes = tex.EncodeToPNG();
			//System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
			
			Color[] bv = tex.GetPixels();

			Color test = new Color (0.129F, 0.694F, 0.302F, 1F);
			if (test.ToString () == bv.GetValue (0).ToString ()) {
				character.Move(1,false,true);
			}
			//Debug.Log (test.ToString() + "  Bnana");
			//Debug.Log (bv.GetValue (0).ToString());


			if (count++ > 100) {
				count = 0;
			}


		}
		
	}
}