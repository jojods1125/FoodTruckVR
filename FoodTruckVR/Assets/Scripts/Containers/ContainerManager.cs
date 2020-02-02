using UnityEngine;

/** Manager for all asset containers in the game for other classes to ask it */
public class ContainerManager : MonoBehaviour
{
	/** Reference that every other class can access */
	public static ContainerManager SharedInstance;

	[SerializeField]
	private PickupIngredientContainer _PickupIngredientContainer;
	public PickupIngredientContainer PickupIngredientContainer
	{
		get { return _PickupIngredientContainer; }
	}


	[SerializeField]
    private IngredientMeshContainer _IngredientMeshContainer;

    public IngredientMeshContainer IngredientMeshContainer
    {
        get{ return _IngredientMeshContainer;}
    }


	[SerializeField]
	private PickupIngredientContainer _RefillContainer;

	public PickupIngredientContainer RefillContainer
	{
		get { return _RefillContainer; }
	}

	/** Initialize share instance */
	void Awake()
	{
		if(SharedInstance == null)
		{
			SharedInstance = this;
		}
	}

}
