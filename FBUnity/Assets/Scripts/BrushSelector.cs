


using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BrushSelector : MonoBehaviour 
{
	#region Variables

	// The pain brush we are affecting
	public D2D_ExplosionStamp brush;

	#endregion


	#region Button Responses

	// Selects the cleaning brush
	public void CleaningBrushSelected ()
	{
		Debug.Log ("Cleaning Brush Selected!");
	}


	//
	//
	public void BrushSizeChanged (int size)
	{
		switch (size)
		{
			case 1: brush.Size = new Vector2 (0.25f, 0.25f); break;
			case 2: brush.Size = new Vector2 (0.5f, 0.5f); break;
			case 3: brush.Size = new Vector2 (1f, 1f); break;
		}
	}


	//
	//
	public void ResetButtonPressed ()
	{

	}


	//
	//
	public void CycleBackgroundButtonPressed ()
	{
		
	}

	#endregion
}
