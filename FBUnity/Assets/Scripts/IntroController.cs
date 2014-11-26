using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroController : MonoBehaviour 
{
	#region Varaibles

	// The gameobjects to spawn after the splash screen
	public GameObject controllerObj;
	public GameObject bearObj;
	public D2D_ClickToSpawn spawner;

	//
	public Image splashScreen;
	public Image s88Logo;
	public Image kidtvLogo;

	//
	public int introstage = 1;

	#endregion


	// Use this for initialization
	void Awake () 
	{
		spawner.SpawnPrefabs ();
		spawner.enabled = false;
		Invoke ("Stage2", 2.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (introstage)
		{
			case 1:
				s88Logo.color = Color.Lerp (s88Logo.color, Color.white, Time.deltaTime * 5.0f);
			break;
			case 2:
				s88Logo.color = Color.Lerp (s88Logo.color, Color.clear, Time.deltaTime * 5.0f);
			break;
			case 3:
				kidtvLogo.color = Color.Lerp (kidtvLogo.color, Color.white, Time.deltaTime * 5.0f);
			break;
			case 4:
				kidtvLogo.color = Color.Lerp (kidtvLogo.color, Color.clear, Time.deltaTime * 5.0f);
			break;
			case 5:
				splashScreen.color = Color.Lerp (splashScreen.color, Color.clear, Time.deltaTime * 8.0f);
			break;
		}
	}

	void Stage2 ()
	{
		introstage = 2;
		Invoke ("Stage3", 1.0f);
	}

	void Stage3 ()
	{
		introstage = 3;
		Invoke ("Stage4", 2.5f);
	}

	void Stage4 ()
	{
		introstage = 4;
		Invoke ("Stage5", 1.0f);
	}

	void Stage5 ()
	{
		introstage = 5;
		Invoke ("Finish", 0.5f);
	}

	void Finish ()
	{
		controllerObj.SetActive (true);
		bearObj.SetActive (true);
		spawner.enabled = true;

		splashScreen.gameObject.SetActive (false);
		kidtvLogo.gameObject.SetActive (false);
		s88Logo.gameObject.SetActive (false);
	}
}
