using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Represents a single ingredient and all the different models that exist for that ingredient */
[CreateAssetMenu(menuName = "Container Asset/IngredientGroup")]
public class IngredientGroup : ScriptableObject
{
	/** The type of the ingredients in this collection */
	public IngredientType CollectionType;

	[Header("Place largest item at front of list, then continue with scale")]
	/** List of models for this ingredient type, ordered by size (largest at index 0) */
	[SerializeField]
	private List<Ingredient> IngredientModels;

	/** Return the ingredient at the given index or null if DNE */
	public Ingredient GetIngredientByIndex(int inIndex)
	{
		if(inIndex > IngredientModels.Count)
		{
			return null;
		}
		return IngredientModels[inIndex];
	}
}
