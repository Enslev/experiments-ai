using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	public Transform player;
	private int count = 0;

	void Update () {
	
		transform.position = new Vector3 (player.position.x + 5, 0, -10);
	
	}
	
	
	private void OnPostRender() {
		count++;

		if (count > 100) {
			Texture2D tex = new Texture2D(50, 25, TextureFormat.RGB24, false);
			
			// Read screen contents into the texture
			tex.ReadPixels(new Rect(90, 123, 50, 25), 0, 0);
			tex.Apply();

			Color[] bv = tex.GetPixels();

			byte[] bytes = tex.EncodeToPNG();
			System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

			/*
			// Object.Destroy(tex);

			Color32[] colorArray = new Color32[64*48];
			int index = 0;
	

			for (int i = 0; i < 640; i+=10) {
				for (int j = 0; j < 480; j+=10) {
					colorArray[index] = averageColor(tex, 0, 0, 10);
					index++;
				}
			}


			Texture2D destTex = new Texture2D(64, 48);
			destTex.SetPixels32(colorArray);
			destTex.Apply();


			//Debug.Log(averageColor(tex, 0, 0, 10).ToString());
			*/

			count = 0;

		}

	}

	public Texture2D getTexture() {
		Texture2D tex = new Texture2D(320, 150, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(75, 100, 320, 150), 0, 0);
		tex.Apply();

		return tex;
	}

	private Color32 averageColor(Texture2D tex, int startX, int startY, int chunk) {

		Color[] pix = tex.GetPixels(startX, startY, chunk, chunk);
		Texture2D destTex = new Texture2D(chunk, chunk);
		destTex.SetPixels(pix);
		destTex.Apply();

		// Encode texture into PNG
		//byte[] bytes = destTex.EncodeToPNG();
		//System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

		return averageColor32Array(destTex.GetPixels32());


	}

	private Color32 averageColor32Array(Color32[] col) {
		int total = col.Length;
		float r = 0; float g = 0; float b = 0;
		
		for(int i = 0; i < total; i++) {
			r += col[i].r;
			g += col[i].g;
			b += col[i].b;
			
		}
		return new Color32((byte)(r / total) , (byte)(g / total) , (byte)(b / total) , 255);
	}


}
