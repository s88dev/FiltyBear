using UnityEngine;

[AddComponentMenu(D2D_Helper.ComponentMenuPrefix + "Click To Stamp")]
public class testbrush : MonoBehaviour
{
	public LayerMask Layers = -1;
	
	public Texture2D StampTex;
	
	public Vector2 Size = Vector2.one;
	
	public float Angle;
	
	public float Hardness = 1.0f;
	
	protected virtual void Update()
	{
		if (Input.GetMouseButton(0))
		{
			var ray      = Camera.main.ScreenPointToRay(Input.mousePosition);
			var distance = D2D_Helper.Divide(ray.origin.z, ray.direction.z);
			var point    = ray.origin - ray.direction * distance;
			
			D2D_Destructible.StampAll(point, Size, Angle, StampTex, Hardness, Layers);
		}
	}

//	void Update ()
//	{
//		var ray      = Camera.main.ScreenPointToRay(Input.mousePosition);
//		var distance = D2D_Helper.Divide(ray.origin.z, ray.direction.z);
//		var point    = ray.origin - ray.direction * distance;
//		if (Input.GetMouseButton(0))
//		{
//
//			
//			D2D_Destructible.StampAll(point, Size, Angle, StampTex, Hardness, Layers);
//		}
//	}

}