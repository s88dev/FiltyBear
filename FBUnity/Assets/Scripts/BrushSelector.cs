


using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BrushSelector : MonoBehaviour 
{
	#region Variables

	// The pain brush we are affecting
	public D2D_ExplosionStamp brush;
	// The bear gameObject we respawn sfter every reset
	public GameObject bearPrefab;
	// The possible background colors
	public Color [] backgroundColors;
	// The renderer for the baskground
	public Renderer backgroundRend;
	// The position at which we spawn the bear
	private Vector3 _prefabSpawnPosition;
	// The current brush size
	private int _currentBrushSize;
	// The current Bear Object
	private bool _isInitialBear = true;

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
		switch (_currentBrushSize)
		{
			case 1: _currentBrushSize = 2; brush.Size = new Vector2 (0.5f, 0.5f); break;
			case 2: _currentBrushSize = 3; brush.Size = new Vector2 (1f, 1f); break;
			case 3: _currentBrushSize = 1; brush.Size = new Vector2 (0.25f, 0.25f); break;
		}
	}


	//
	//
	public void ResetButtonPressed ()
	{
		//
		if (_isInitialBear)
			Destroy (GameObject.Find ("Bear"));
		else
			Destroy (GameObject.Find ("Bear(Clone)"));

		//
		Instantiate (bearPrefab, _prefabSpawnPosition, Quaternion.identity);

		//
		_isInitialBear = false;
		ChangeBackgroundColor ();
	}

	#endregion


	//
	void ChangeBackgroundColor ()
	{
		// Get a random color
		Color col = backgroundColors [Random.Range (0, backgroundColors.Length)];
		backgroundRend.material.color = col;
	}


	//
	void Start ()
	{
		_prefabSpawnPosition = GameObject.Find ("Bear").transform.position;
	}
}
