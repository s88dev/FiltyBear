using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour 
{
	#region Variables

	// The sound effect source
	public AudioSource seSource;

	#endregion


	// Use this for initialization
	void Start () {
	
	}
	
	// Plays an audio clip
	public void PlaySound (string name)
	{
		switch (name)
		{
		case "Reset":

			break;

		case "Brush":

			break;
		}
	}
}
