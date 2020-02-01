using System.Collections.Generic;
using UnityEngine;

/** All possible food containers in the game */
public enum FoodContainerType
{
	Taco,
	Bowl
}

/** Attached to a food container in game so it can track what ingredients it currently holds */
public class FoodContainer : MonoBehaviour
{
	/// <summary>
	/// List of "sockets" for attaching an ingredient model to the container.
	/// Starts at front of list and continues (socket at index 0 used first)
	/// </summary>
	public List<Transform> Sockets;

	/// <summary>
	/// All ingredients currently attached to this container
	/// </summary>
	public List<Ingredient> Ingredients;
}
