using System.Collections.Generic;
using UnityEngine;

/** Container for ingredients and how they can be represented in the world as grabbable objects */
[CreateAssetMenu(menuName = "Container Asset/PickupIngredientContainer")]
public class PickupIngredientContainer : ScriptableObject
{
    /** List of all ingredient groups in the game */
	[SerializeField]
	private List<Ingredient> _PickupIngredients;

	public IEnumerable<Ingredient> AllContent
	{
		get { return _PickupIngredients; }
	}

	/** Return the ingredient that is sized for the layer specified */
	public GameObject GetIngredientModelByType(IngredientType inType)
	{
		foreach (Ingredient ingredient in _PickupIngredients) 
		{
			if(ingredient.IngredientType == inType)
			{
				//Spawn the ingredient in world and return to caller
				GameObject newIngredient = Instantiate(ingredient.gameObject);
				return newIngredient;
			}
		}

		return null;
	}

	/** Return the ingredient that is sized for the layer specified */
	public GameObject GetContainerModelByType(FoodContainerType inType)
	{
		foreach (FoodContainer ingredient in _PickupIngredients)
		{
			if (ingredient.cont == inType)
			{
				//Spawn the ingredient in world and return to caller
				GameObject newIngredient = Instantiate(ingredient.gameObject);
				return newIngredient;
			}
		}

		return null;
	}
}
