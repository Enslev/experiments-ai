using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{
	
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class NeuralNetwork : MonoBehaviour
	{
		private PlatformerCharacter2D character;
		public Transform player;
		
		private void Awake()
		{
			character = GetComponent<PlatformerCharacter2D>();

		}
		
		private void Update()
		{	
			if (player.position.x > 10) {
				character.Move(1,false,true);
			}
		}

		
	}
}