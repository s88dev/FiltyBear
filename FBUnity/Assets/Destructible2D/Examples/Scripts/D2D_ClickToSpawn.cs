using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu(D2D_Helper.ComponentMenuPrefix + "Click To Spawn")]
public class D2D_ClickToSpawn : MonoBehaviour
{
	public GameObject Prefab;
	public int prefabPoolSize = 4;
	D2D_ExplosionStamp [] prefabs;
	public KeyCode Requires = KeyCode.Mouse0;
	private Vector3 _previousPoint = Vector3.zero;
	public Transform smallCursor;
	public Transform mediumCursor;
	public Transform largeCursor;
	private int sizeBrushNum = 1;
	//
	public Transform faceReactionCenter;
	public Transform buttReactionCenter;
	//
	public BrushSelector controller;
	public AudioSource rubSource;


	/*
	protected virtual void Update()
	{
		if (Input.GetKeyDown(Requires) == true && Prefab != null && Camera.main != null)
		{
			var ray      = Camera.main.ScreenPointToRay (Input.mousePosition);
			var distance = D2D_Helper.Divide (ray.origin.z, ray.direction.z);
			var point    = ray.origin - ray.direction * distance;
			
			D2D_Helper.CloneGameObject (Prefab, null).transform.position = point;
		}
	}*/


	//
	public void ChangeBrushSize (float size, int sizeNum)
	{
		for (int i = 0; i < prefabs.Length; i++)
			prefabs [i].Size = new Vector2 (size, size);
		sizeBrushNum = sizeNum;
	}

	//
	void Update ()
	{
		//
		if (Input.GetMouseButtonDown (0))
		{
			switch (sizeBrushNum)
			{
				case 1: smallCursor.GetComponent <Image> ().enabled = true; rubSource.pitch = 1.3f; break;
				case 2: mediumCursor.GetComponent <Image> ().enabled = true; rubSource.pitch = 1f; break;
				case 3: largeCursor.GetComponent <Image> ().enabled = true; rubSource.pitch = 0.8f; break;
			}
			rubSource.volume = 0.35f;
		}

		if (Input.GetMouseButton (0))
		{
			// Mouse position coordinates n stuff
			Vector3 mousePos = Input.mousePosition;
			float xMouse = mousePos.x / Screen.width;
			float yMouse = mousePos.y / Screen.height;

			//
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float distance = 0;
			Vector3 point = ray.origin - ray.direction * distance;
			smallCursor.position = point;
			mediumCursor.position = point;
			largeCursor.position = point;
			Vector2 pointXY = new Vector2 (point.x, point.y);
			float distanceToFace = Vector2.Distance (pointXY, new Vector2 (faceReactionCenter.position.x, faceReactionCenter.position.y));

			//
			if (_previousPoint != Vector3.zero && sizeBrushNum < 3)
			{
				//
				if (Vector3.Distance (_previousPoint, point) >= 0.12f)
				{
					Vector3 [] midpoint = new Vector3 [3];
					midpoint [0] = ((point + _previousPoint) / 2);
					midpoint [1] = ((midpoint [0] + _previousPoint) / 2);
					midpoint [2] = ((point + midpoint [0]) / 2);

					//
					prefabs [0].Explode (midpoint [0]);
					//prefabs [1].Explode (midpoint [1]);
					prefabs [2].Explode (midpoint [2]);
				}
			}

			//
			prefabs [3].Explode (point);
			_previousPoint = point;

			//
			if (distanceToFace <= 1.2f)
				controller.FaceTouched ();
			else
				controller.FaceUntouched ();

			//
			if ((xMouse <= 0.8f && xMouse >= 0.2f) && (yMouse <= 0.23f && yMouse >= 0.13f))
				controller.ButtTouched ();
			else
				controller.ButtUntouched ();
		}

		//
		if (Input.GetMouseButtonUp (0))
		{
			_previousPoint = Vector3.zero;
			smallCursor.GetComponent <Image> ().enabled = false;
			mediumCursor.GetComponent <Image> ().enabled = false;
			largeCursor.GetComponent <Image> ().enabled = false;
			//controller.ResetTouchedBools ();
			controller.ButtUntouched ();
			controller.FaceUntouched ();
			rubSource.volume = 0.0f;
		}
	}


	public void SpawnPrefabs ()
	{
		// Create the prefab pool
		prefabs = new D2D_ExplosionStamp [prefabPoolSize];
		for (int i = 0; i < prefabPoolSize; i++)
		{
			prefabs [i] = ((GameObject) Instantiate (Prefab, Vector3.zero, Quaternion.identity)).GetComponent <D2D_ExplosionStamp> ();
		}
	}

}