using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour 
{
	#region Variables

	// The sound effect source
	public AudioSource seSource;
	//
	public AudioClip resetButtonclip;
	public AudioClip switchOutfitsButtonclip;
	public AudioClip bearGaspClip;

	#endregion


	// Use this for initialization
	void Start () {
	
	}
	
	// Plays an audio clip
	public void PlaySound (string name)
	{
		seSource.Stop ();
		seSource.volume = 1.0f;
		switch (name)
		{
			case "Reset": seSource.clip = resetButtonclip; break;
			case "Switch": seSource.clip = switchOutfitsButtonclip; break;
			case "Brush": seSource.clip = resetButtonclip; break;
			case "Gasp": seSource.clip = bearGaspClip; seSource.volume = 0.6f; break;
		}
		seSource.Play ();
	}
}
