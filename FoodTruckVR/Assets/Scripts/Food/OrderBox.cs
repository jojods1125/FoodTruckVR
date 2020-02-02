using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBox : MonoBehaviour
{
    int tempRand;
    public bool tacoOrder = false;
    public bool chipOrder = false;
    //public bool beanOrder = false;

    public int tacoTopingTotal = 0;
    public IngredientType tacoSlot1 = IngredientType.None;
    public IngredientType tacoSlot2 = IngredientType.None;
    public IngredientType tacoSlot3 = IngredientType.None;
    public IngredientType tacoSlot4 = IngredientType.None;

    public string chipSlot = "None";

    public Material mat_shell;
    public Material mat_beef;
    public Material mat_cheese;
    public Material mat_lettuce;
    public Material mat_tomato;

    public Material mat_bowl;

    public Material mat_chips;
    public Material mat_queso;
    public Material mat_salsa;

    //public Material mat_beans;

    public Material mat_none;

    public MeshRenderer meshrender;

    public void NewOrder()
    {

        //Mat reset
        resetTacoMats();
        resetChipMats();

        //for mats
        Material[] materials = meshrender.materials;

        resetVars();

        //Order Types
        newRand(6);
        //Debug.Log(tempRand.ToString());
        if (tempRand <= 5)
        {
            tacoOrder = true;
            materials[1] = mat_shell;
        }

        newRand(2);
        if (tempRand <= 1)
        {
            chipOrder = true;
            materials[6] = mat_bowl;
            materials[7] = mat_chips;

        }

        /*newRand(2);
        if (tempRand <= 1)
        {
            beanOrder = true;
            materials[9] = mat_bowl;
            materials[10] = mat_beans;
        }*/

        if (!tacoOrder && !chipOrder)
        {
            tacoOrder = true;
            materials[1] = mat_shell;
        }

        //Taco Order
        if (tacoOrder)
        {
            newRand(4);
            tacoTopingTotal = tempRand;
            if(tacoTopingTotal >= 4)
                tacoSlot4 = newToping(1, 3, 3, 3);
                materials[5] = topingMat(tacoSlot4);
            if (tacoTopingTotal >= 3)
                tacoSlot3 = newToping(1, 3, 3, 3);
                materials[4] = topingMat(tacoSlot3);
            if (tacoTopingTotal >= 2)
                tacoSlot2 = newToping(3, 3, 2, 2);
                materials[3] = topingMat(tacoSlot2);
            if (tacoTopingTotal >= 1)
                tacoSlot1 = newToping(7, 1, 1, 1);
                materials[2] = topingMat(tacoSlot1);
        }

        //Chip Order
        if (chipOrder)
        {
            newRand(2);
            //if (tempRand == 3)
                //chipSlot = "Salsa";
            if (tempRand == 2)
            {
                chipSlot = "Queso";
                materials[8] = mat_queso;
            }
                
            if (tempRand == 1)
            {
                chipSlot = "None";
                materials[8] = mat_chips;
            }
        }

        //for mats
        meshrender.materials = materials;
    }

    public void resetTacoMats()
    {
        //for mats
        Material[] materials = meshrender.materials;

        //Mat reset
        for (int i = 1; i <= 5; i++)
        {
            materials[i] = mat_none;
        }

        //for mats
        meshrender.materials = materials;
    }

    public void resetChipMats()
    {
        //for mats
        Material[] materials = meshrender.materials;

        //Mat reset
        for (int i = 6; i <= 10; i++)
        {
            materials[i] = mat_none;
        }

        //for mats
        meshrender.materials = materials;
    }



    public void newRand(int max)
    {
        //rand int from 0 to max
        tempRand = Random.Range(0, max);
        tempRand += 1;
    }

    public IngredientType newToping(int beeMax, int cheMax, int letMax, int tomMax)
    {
        //rand int from 0 to max
        tempRand = Random.Range(0, beeMax+cheMax+letMax+tomMax);
        tempRand += 1;

        IngredientType newToping = IngredientType.None;

        if(tempRand <= beeMax)
            newToping = IngredientType.Beef;
        if (beeMax < tempRand && tempRand <= (beeMax+cheMax))
            newToping = IngredientType.Cheese;
        if ((beeMax + cheMax) < tempRand && tempRand <= (beeMax + cheMax + letMax))
            newToping = IngredientType.Lettuce;
        if ((beeMax + cheMax + letMax) < tempRand && tempRand <= (beeMax + cheMax + letMax + tomMax))
            newToping = IngredientType.Tomato;

        return newToping;
    }

    public Material topingMat(IngredientType ingred)
    {
        Material tempMat = mat_none;
        switch (ingred)
        {
            case IngredientType.Beef:
                tempMat = mat_beef;
                break;
            case IngredientType.Cheese:
                tempMat = mat_cheese;
                break;
            case IngredientType.Lettuce:
                tempMat = mat_lettuce;
                break;
            case IngredientType.Tomato:
                tempMat = mat_tomato;
                break;
        }

        return tempMat;
    }

    public void resetVars()
    {
        tacoOrder = false;
        chipOrder = false;
        //beanOrder = false;

        tacoTopingTotal = 0;
        tacoSlot1 = IngredientType.None;
        tacoSlot2 = IngredientType.None;
        tacoSlot3 = IngredientType.None;
        tacoSlot4 = IngredientType.None;

        chipSlot = "None";
}

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NewOrder();
        }
    }
}
