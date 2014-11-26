using UnityEngine;
using System.Collections;

public class BearOutfitController : MonoBehaviour 
{
	#region Variables

	// The sprites
	//public SpriteRenderer hipsterBoyFace;
	//public SpriteRenderer hipsterBoyBody;
	//public SpriteRenderer hipsterBoyScarf;
	//public SpriteRenderer hipsterBoyArm1;
	//public SpriteRenderer hipsterBoyArm2;
	public SpriteRenderer [] hipsterBoyOutfit;
	public SpriteRenderer [] hipsterGirlOutfit;

	//
	//public SpriteRenderer hipsterGirlFace;
	//public SpriteRenderer hipsterGirlHair;
	//public SpriteRenderer hipsterGirlBody;
	//public SpriteRenderer hipsterGirlScarf;
	//public SpriteRenderer hipsterGirlArm1;
	//public SpriteRenderer hipsterGirlArm2;

	#endregion
	

	//
	public void ChangeOutfit (int outfitNum)
	{
		switch (outfitNum)
		{
			// None
		case 1: 
			for (int i = 0; i < hipsterBoyOutfit.Length; i++) { hipsterBoyOutfit [i].enabled = false; } 
			for (int i = 0; i < hipsterGirlOutfit.Length; i++) { hipsterGirlOutfit [i].enabled = false; } 
			break;
		case 2: 
			for (int i = 0; i < hipsterGirlOutfit.Length; i++) { hipsterGirlOutfit [i].enabled = false; }
			for (int i = 0; i < hipsterBoyOutfit.Length; i++) { hipsterBoyOutfit [i].enabled = true; } 
			break;
		case 3: 
			for (int i = 0; i < hipsterGirlOutfit.Length; i++) { hipsterGirlOutfit [i].enabled = true; }
			for (int i = 0; i < hipsterBoyOutfit.Length; i++) { hipsterBoyOutfit [i].enabled = false; } 
			break;
		}
	}
}
