


using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BrushSelector : MonoBehaviour 
{
	#region Variables

	//
	public Vector2 blinkWaitTimeRange = new Vector2 (2, 10);
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
	//
	public D2D_ClickToSpawn spawner;
	//
	public Sprite faceSpriteNormal;
	public Sprite faceSpriteBlink;
	public Sprite faceSpriteCringe;
	public Sprite faceSpriteO;
	//
	public Image [] brushSizeIndicators;
	//
	public Image smallBrushActive;
	public Image mediumBrushActive;
	public Image largeBrushActive;
	// The position at which we spawn the bear
	private Vector3 _prefabSpawnPosition;
	// The current brush size
	private int _currentBrushSize = 1;
	// The current Bear Object
	private bool _isInitialBear = true;
	// The index of the current background color
	private int _currentBackgroundIndex = 0;
	// The sprite renderers
	private SpriteRenderer underwearRend;
	private SpriteRenderer faceRend;
	//
	private bool _isSwitchingBrush = false;

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
			case 1: _currentBrushSize = 2; spawner.ChangeBrushSize (0.5f, 2); break;
			case 2: _currentBrushSize = 3; spawner.ChangeBrushSize (1f, 3); break;
			case 3: _currentBrushSize = 1; spawner.ChangeBrushSize (0.25f, 1); break;
		}

		smallBrushActive.enabled = false;
		mediumBrushActive.enabled = false;
		largeBrushActive.enabled = false;
		switch (_currentBrushSize)
		{
			case 1: smallBrushActive.enabled = true; smallBrushActive.color = Color.white; break;
			case 2: mediumBrushActive.enabled = true; mediumBrushActive.color = Color.white; break;
			case 3: largeBrushActive.enabled = true; largeBrushActive.color = Color.white; break;
		}

		//
		for (int i = 0; i < brushSizeIndicators.Length; i ++)
		{
			brushSizeIndicators [i].color = Color.white;
		}

		//
		if (_isSwitchingBrush)
			CancelInvoke ();

		Invoke ("ClearBrushIndicators", 0.5f);
		_isSwitchingBrush = true;
	}


	//
	void ClearBrushIndicators ()
	{
		_isSwitchingBrush = false;
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
		underwearRend = b.transform.GetChild (0).GetChild (1).gameObject.GetComponent <SpriteRenderer> ();
		faceRend = b.transform.GetChild (1).GetChild (1).gameObject.GetComponent <SpriteRenderer> ();

		//
		_isInitialBear = false;
		ChangeBackgroundColor ();
		ChangeUnderwear ();
	}

	#endregion


	#region Update

	//
	void Update ()
	{
		if (_isSwitchingBrush)
			return;

		//
		for (int i = 0; i < brushSizeIndicators.Length; i ++)
			brushSizeIndicators [i].color = Color.Lerp (brushSizeIndicators [i].color, Color.clear, Time.deltaTime * 10.0f);
		smallBrushActive.color = Color.Lerp (smallBrushActive.color, Color.clear, Time.deltaTime * 10.0f);
		mediumBrushActive.color = Color.Lerp (smallBrushActive.color, Color.clear, Time.deltaTime * 10.0f);
		largeBrushActive.color = Color.Lerp (smallBrushActive.color, Color.clear, Time.deltaTime * 10.0f);
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
		Sprite s = underwearSprites [Random.Range (0, underwearSprites.Length)];
		underwearRend.sprite = s;
	}


	// 1 = normal, 2 = blink, 3 = cringe, 4 = O
	public void ChangeFace (int faceType)
	{
		Sprite s = null;
		switch (faceType)
		{
			case 1: s = faceSpriteNormal; break;
			case 2: s = faceSpriteBlink; break;
			case 3: s = faceSpriteCringe; break;
			case 4: s = faceSpriteO; break;
		}
		faceRend.sprite = s;
	}


	//
	void Blink ()
	{
		faceRend.sprite = faceSpriteBlink;
		Invoke ("Unblink", 0.1f);
	}


	//
	void Unblink ()
	{
		faceRend.sprite = faceSpriteNormal;
		Invoke ("Blink", Random.Range (blinkWaitTimeRange.x, blinkWaitTimeRange.y));
	}


	//
	void Start ()
	{
		_prefabSpawnPosition = GameObject.Find ("Bear").transform.position;
		faceRend = GameObject.Find ("Bear").transform.GetChild (1).GetChild (1).gameObject.GetComponent <SpriteRenderer> ();

		Invoke ("Blink", Random.Range (blinkWaitTimeRange.x, blinkWaitTimeRange.y));
	}
}
