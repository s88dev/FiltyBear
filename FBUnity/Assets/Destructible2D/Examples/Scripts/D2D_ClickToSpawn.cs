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
				case 1: smallCursor.GetComponent <Image> ().enabled = true; break;
				case 2: mediumCursor.GetComponent <Image> ().enabled = true; break;
				case 3: largeCursor.GetComponent <Image> ().enabled = true; break;
			}
		}

		if (Input.GetMouseButton (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float distance = 0;
			Vector3 point = ray.origin - ray.direction * distance;
			smallCursor.position = point;
			mediumCursor.position = point;
			largeCursor.position = point;

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
					//prefabs [2].Explode (midpoint [2]);
				}
			}

			//
			prefabs [3].Explode (point);
			_previousPoint = point;
		}

		//
		if (Input.GetMouseButtonUp (0))
		{
			_previousPoint = Vector3.zero;
			smallCursor.GetComponent <Image> ().enabled = false;
			mediumCursor.GetComponent <Image> ().enabled = false;
			largeCursor.GetComponent <Image> ().enabled = false;
		}
	}

	void Start ()
	{
		// Create the prefab pool
		prefabs = new D2D_ExplosionStamp [prefabPoolSize];
		for (int i = 0; i < prefabPoolSize; i++)
		{
			prefabs [i] = ((GameObject) Instantiate (Prefab, Vector3.zero, Quaternion.identity)).GetComponent <D2D_ExplosionStamp> ();
		}
	}

}