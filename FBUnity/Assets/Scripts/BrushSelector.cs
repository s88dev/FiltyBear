


using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BrushSelector : MonoBehaviour 
{
	#region Variables

	// The pain brush we are affecting
	public D2D_ExplosionStamp brush;
	public Slider sizeSlider;

	#endregion


	#region Button Responses

	// Selects the cleaning brush
	public void CleaningBrushSelected ()
	{
		Debug.Log ("Cleaning Brush Selected!");
	}


	//
	//
	public void BrushSizeChanged ()
	{
		float f = sizeSlider.value;
		brush.Size = new Vector2 (f, f);
	}

	#endregion
	

	#region Initialization

	// Used for initialization
	void Start () 
	{
		
	}

	#endregion
}
