using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject startScreen;

	public bool gameStarted = false;

	public void ClearScreen()
	{
		startScreen.SetActive(false);
		gameStarted = true;
	}

}
