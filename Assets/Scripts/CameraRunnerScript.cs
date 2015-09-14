using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	public Transform player;
	private int count = 0;

	void Update () {
	
		transform.position = new Vector3 (player.position.x + 5, 0, -10);
	
	}


}
