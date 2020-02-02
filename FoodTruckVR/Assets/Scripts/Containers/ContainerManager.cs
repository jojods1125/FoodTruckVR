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
	private IngredientMeshContainer _BowlMeshContainer;

	public IngredientMeshContainer BowlMeshContainer
	{
		get { return _BowlMeshContainer; }
	}


	[SerializeField]
	private PickupIngredientContainer _RefillContainer;

	public PickupIngredientContainer RefillContainer
	{
		get { return _RefillContainer; }
	}

	[SerializeField]
	private PickupIngredientContainer _InfiniteContainer;

	public PickupIngredientContainer InfiniteContainer
	{
		get { return _InfiniteContainer; }
	}

	[SerializeField]
	private PickupIngredientContainer _ContainerContainer;

	public PickupIngredientContainer ContainerContainer
	{
		get { return _ContainerContainer; }
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
