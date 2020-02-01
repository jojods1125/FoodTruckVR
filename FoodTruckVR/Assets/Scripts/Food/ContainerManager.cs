using UnityEngine;

/** Manager for all asset containers in the game for other classes to ask it */
public class ContainerManager : MonoBehaviour
{
	/** Reference that every other class can access */
	public static ContainerManager SharedInstance;

	/** Reference to the mesh container */
	[SerializeField]
	private IngredientMeshContainer _IngredientMeshContainer;
}
