using System.Collections.Generic;
using UnityEngine;

/** Container of all meshes for ingredients */
[CreateAssetMenu(menuName = "Container Asset/IngredientContainer")]
public class IngredientMeshContainer : ScriptableObject
{
	/** List of all ingredient groups in the game */
	[SerializeField]
	private List<IngredientGroup> IngredientGroups;

	public IEnumerable<IngredientGroup> AllContent
	{
		get { return IngredientGroups; }
	}

	/** Return the ingredient that is sized for the layer specified */
	public GameObject GetIngredientForLayer(IngredientType inType, int inSocket)
	{
		foreach (IngredientGroup group in IngredientGroups) 
		{
			if(group.CollectionType == inType)
			{
				//get the object to spawn
				Ingredient ingredientToSpawn = group.GetIngredientByIndex(inSocket);

				//If DNE, return null
				if(ingredientToSpawn == null)
				{
					return null;
				}

				//Spawn the ingredient in world and return to caller
				GameObject newIngredient = Instantiate(ingredientToSpawn.gameObject);
				return newIngredient;
			}
		}

		return null;
	}
}
