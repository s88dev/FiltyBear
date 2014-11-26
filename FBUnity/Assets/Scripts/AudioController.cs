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

	#endregion


	// Use this for initialization
	void Start () {
	
	}
	
	// Plays an audio clip
	public void PlaySound (string name)
	{
		seSource.Stop ();
		switch (name)
		{
			case "Reset": seSource.clip = resetButtonclip; break;
			case "Switch": seSource.clip = switchOutfitsButtonclip; break;
			case "Brush": seSource.clip = resetButtonclip; break;
		}
		seSource.Play ();
	}
}
