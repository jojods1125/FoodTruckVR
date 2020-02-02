using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCab : MonoBehaviour
{

    public GameObject bowSpawn;
    //public GameObject ladSpawn;

    int hasBow = 0;
    //int hasLad = 0;

    public FoodContainer RefillTempPref;

    void OnTriggerEnter(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<FoodContainer>().cont)
        {
            case FoodContainerType.Bowl:
                hasBow += 1;
                break;

            //case FoodContainerType.Ladle:
                //hasLad += 1;
                //break;
        }
    }

    void OnTriggerExit(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<FoodContainer>().cont)
        {
            case FoodContainerType.Bowl:
                hasBow -= 1;
                break;

            //case FoodContainerType.Ladle:
                //hasLad -= 1;
                //break;
        }
    }

    private void StorageFill()
    {
        ContainerManager containerManager = ContainerManager.SharedInstance;

        //get pickup container
        PickupIngredientContainer refillContainer = containerManager.ContainerContainer;

        //Refill tempRefillInst;

        if (hasBow <= 0)
        {
            refillContainer.GetContainerModelByType(FoodContainerType.Bowl).transform.position = bowSpawn.transform.position;
            //tempRefillInst = Instantiate(RefillTempPref);
            //tempRefillInst.IngredientType = IngredientType.Chip;
            //tempRefillInst.transform.position = chiSpawn.transform.position;
        }
        //if (hasLad <= 0)
        //{
        //    refillContainer.GetContainerModelByType(FoodContainerType.Ladle);
           // shell.transform.position = ladSpawn.transform.position;
            //shell.transform.localScale = new Vector3(40, 40, 40);
            //tempRefillInst = Instantiate(RefillTempPref);
            //tempRefillInst.IngredientType = IngredientType.Shell;
            //tempRefillInst.transform.position = sheSpawn.transform.position;
        //}
    }

    private void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //Debug.Log("pressed space");
        StorageFill();
        //}
    }
}
