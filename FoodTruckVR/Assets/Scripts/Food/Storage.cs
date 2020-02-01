using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public GameObject cheSpawn;
    public GameObject letSpawn;
    public GameObject tomSpawn;

    int hasChe = 0;
    int hasLet = 0;
    int hasTom = 0;

    public Refill RefillTempPref;

    public void StorageClose()
    {
        
    }

    void OnTriggerEnter(Collider refillCollide)
    {

            switch (refillCollide.GetComponent<Refill>().IngredientType)
            {
                case IngredientType.Cheese:
                hasChe += 1;
                break;

                case IngredientType.Lettuce:
                hasLet += 1;
                break;

                case IngredientType.Tomato:
                hasTom += 1;
                break;
            }
    }

    void OnTriggerExit(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<Refill>().IngredientType)
        {
            case IngredientType.Cheese:
                hasChe -= 1;
                break;

            case IngredientType.Lettuce:
                hasLet -= 1;
                break;

            case IngredientType.Tomato:
                hasTom -= 1;
                break;
        }
    }

    private void StorageFill()
    {
            Refill tempRefillInst;

            Debug.Log("make something");
            Debug.Log(hasChe.ToString() + hasLet.ToString() + hasTom.ToString());

            if (hasChe <= 0)
            {
                tempRefillInst = Instantiate(RefillTempPref);
                tempRefillInst.IngredientType = IngredientType.Cheese;
                tempRefillInst.transform.position = cheSpawn.transform.position;
                Debug.Log("make cheese");
            }
            if (hasLet <= 0)
            {
                tempRefillInst = Instantiate(RefillTempPref);
                tempRefillInst.IngredientType = IngredientType.Lettuce;
                tempRefillInst.transform.position = letSpawn.transform.position;
        }
            if (hasTom <= 0)
            {
                tempRefillInst = Instantiate(RefillTempPref);
                tempRefillInst.IngredientType = IngredientType.Tomato;
                tempRefillInst.transform.position = tomSpawn.transform.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("pressed space");
            StorageFill();
        }
    }
}
