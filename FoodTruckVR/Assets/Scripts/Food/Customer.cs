using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public OrderBox currentOrder;
    private bool OrderCorrect = false;

    //The following was added by Drumstick to have a new car color for each order
    System.Random sysRNG = new System.Random();

    public MeshRenderer meshrender;

    public Material[] paintMats = new Material[10];

    public void newCustomerPaint()
    {
        Material[] carMaterials = meshrender.materials;

        carMaterials[1] = paintMats[sysRNG.Next(0, paintMats.Length)];
        meshrender.materials = carMaterials;
    }
    //


    void OnCollisionEnter(Collision orderCollide)
    {
        
        if (orderCollide.gameObject.CompareTag("Taco"))
        {
            Debug.Log("taco collide");
            List<IngredientType> tacoOrder = orderCollide.gameObject.GetComponent<FoodContainer>().Ingredients;
            //Debug.Log(tacoOrder[3].IngredientType);

            //add 4 nones so the list is at least 4 long
            tacoOrder.Add(IngredientType.None);
            tacoOrder.Add(IngredientType.None);
            tacoOrder.Add(IngredientType.None);
            tacoOrder.Add(IngredientType.None);

            OrderCorrect = true;

            if (!currentOrder.tacoOrder)
            {
                OrderCorrect = false;
            }
            if (currentOrder.tacoTopingTotal >= 1)
            {
                if (tacoOrder[0] != currentOrder.tacoSlot1)
                    OrderCorrect = false;
            }
            if (currentOrder.tacoTopingTotal >= 2)
            {
                if (tacoOrder[1] != currentOrder.tacoSlot2)
                    OrderCorrect = false;
            }
            if (currentOrder.tacoTopingTotal >= 3)
            {
                if (tacoOrder[2] != currentOrder.tacoSlot3)
                    OrderCorrect = false;
            }
            if (currentOrder.tacoTopingTotal >= 4)
            {
                if (tacoOrder[3] != currentOrder.tacoSlot4)
                    OrderCorrect = false;
            }

            if (OrderCorrect)
            {
                Debug.Log("taco order correct!");
                currentOrder.tacoOrder = false;
                currentOrder.tacoSlot1 = IngredientType.None;
                currentOrder.tacoSlot2 = IngredientType.None;
                currentOrder.tacoSlot3 = IngredientType.None;
                currentOrder.tacoSlot4 = IngredientType.None;

                currentOrder.resetTacoMats();

                currentOrder.resetPatience();
            }
            else
            {
                Debug.Log("taco W R O N G");
            }


        }



        if (orderCollide.gameObject.CompareTag("ChipBowl"))
        {
            Debug.Log("chip collide");
            List<IngredientType> chipOrder = orderCollide.gameObject.GetComponent<FoodContainer>().Ingredients;
            //Debug.Log(chipOrder[3].IngredientType);

            //add 4 nones so the list is at least 4 long
            chipOrder.Add(IngredientType.None);
            chipOrder.Add(IngredientType.None);

            OrderCorrect = true;

            if (!currentOrder.chipOrder)
            {
                OrderCorrect = false;
            }
            if (currentOrder.chipSlot == "None")
            {
                if (chipOrder[1] != IngredientType.Chip)
                    OrderCorrect = false;
            }
            if (currentOrder.chipSlot == "Queso")
            {
                if (chipOrder[1] != IngredientType.Queso)
                    OrderCorrect = false;
            }

            if (OrderCorrect)
            {
                Debug.Log("chip correct!");
                currentOrder.chipOrder = false;
                currentOrder.chipSlot = "None";

                currentOrder.resetChipMats();

                currentOrder.resetPatience();
            }
            else
            {
                Debug.Log("chip W R O N G");
            }


        }
        

        /*CHECK FOR COMPLETE ORDER*/
        if (!currentOrder.tacoOrder && !currentOrder.chipOrder)
        {
            currentOrder.NewOrder();
        }
    }
}
