using System.Collections.Generic;
using UnityEngine;

/** Represents a single ingredient and all the different models that exist for that ingredient */
[CreateAssetMenu(menuName = "Container Asset/IngredientGroup")]
public class IngredientGroup : ScriptableObject
{
	/** The type of the ingredients in this collection */
	public IngredientType CollectionType;

	[Header("Place smallest item at front of list, then continue with scale")]
	/** List of models for this ingredient type, ordered by size (smallest at index 0) */
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

	/** Return the mesh for an ingredient that is sized for the layer specified */
	public Ingredient GetIngredientForLayer(IngredientType inType, int inSocket)
	{
		foreach (IngredientGroup group in IngredientGroups) 
		{
			if(group.CollectionType == inType)
			{
				return group.GetIngredientByIndex(inSocket);
			}
		}

		return null;
	}
}
