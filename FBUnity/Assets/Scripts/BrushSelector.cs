


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
	//
	public Sprite [] underwearSprites;
	// The renderer for the baskground
	public Renderer backgroundRend;
	// The position at which we spawn the bear
	private Vector3 _prefabSpawnPosition;
	// The current brush size
	private int _currentBrushSize = 1;
	// The current Bear Object
	private bool _isInitialBear = true;
	// The index of the current background color
	private int _currentBackgroundIndex = 0;
	// The sprite renderer for the underwear
	private SpriteRenderer underwearRend;

	#endregion


	#region Button Responses

	// Selects the cleaning brush
	public void CleaningBrushSelected ()
	{
		Debug.Log ("Cleaning Brush Selected!");
	}


	// Changes the brush size
	public void BrushSizeChanged ()
	{
		switch (_currentBrushSize)
		{
			case 1: _currentBrushSize = 2; brush.Size = new Vector2 (0.5f, 0.5f); break;
			case 2: _currentBrushSize = 3; brush.Size = new Vector2 (1f, 1f); break;
			case 3: _currentBrushSize = 1; brush.Size = new Vector2 (0.25f, 0.25f); break;
		}
	}


	// Resets the bear & background color
	public void ResetButtonPressed ()
	{
		// Destroy the bear currently on screen
		if (_isInitialBear)
			Destroy (GameObject.Find ("Bear"));
		else
			Destroy (GameObject.Find ("Bear(Clone)"));

		// Instantiate the new bear and set the background color
		GameObject b = (GameObject) Instantiate (bearPrefab, _prefabSpawnPosition, Quaternion.identity);
		underwearRend = b.GetComponent <SpriteRenderer> ();

		//
		_isInitialBear = false;
		ChangeBackgroundColor ();
		ChangeUnderwear ();
	}

	#endregion


	// Changes the background color
	void ChangeBackgroundColor ()
	{
		// Get the next background color
		_currentBackgroundIndex ++;
		if (_currentBackgroundIndex > (backgroundColors.Length - 1))
			_currentBackgroundIndex = 0;

		// Set the color
		Color col = backgroundColors [_currentBackgroundIndex];
		backgroundRend.material.color = col;
	}


	//
	void ChangeUnderwear ()
	{
		//
		Sprite s = underwearSprites [Random.Range (0, underwearSprites.Length)];
		underwearRend.sprite = s;
	}


	//
	void Start ()
	{
		_prefabSpawnPosition = GameObject.Find ("Bear").transform.position;
	}
}
