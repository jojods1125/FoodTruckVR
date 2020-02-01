using System.Collections.Generic;
using UnityEngine;

/** Container of all meshes for ingredients */
public class IngredientMeshContainer : ScriptableObject
{
	/** Maps meshes to the socket level that they can be attached to */
	public Dictionary<Ingredient, int> IngredientMeshes;

	/** Return the mesh for an ingredient that is sized for the layer specified */
	public GameObject GetIngredientForLayer(IngredientType inType, int inSocket)
	{
		foreach (KeyValuePair<Ingredient, int> ingredientLayerPair in IngredientMeshes)
		{
			Ingredient ingredient = ingredientLayerPair.Key;
			int layer = ingredientLayerPair.Value;

			if (ingredient.IngredientType == inType && layer == inSocket)
			{
				return ingredient.gameObject;
			}
		}

		return null;
	}
}
