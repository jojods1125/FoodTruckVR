using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public GameObject chiSpawn;
    public GameObject sheSpawn;

    int hasChi = 0;
    int hasShe = 0;

    public Refill RefillTempPref;


    void OnTriggerEnter(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<Refill>().IngredientType)
        {
            case IngredientType.Chip:
                hasChi += 1;
                break;

            case IngredientType.Shell:
                hasShe += 1;
                break;
        }
    }

    void OnTriggerExit(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<Refill>().IngredientType)
        {
            case IngredientType.Chip:
                hasChi -= 1;
                break;

            case IngredientType.Shell:
                hasShe -= 1;
                break;
        }
    }

    private void StorageFill()
    {
        Refill tempRefillInst;

        if (hasChi <= 0)
        {
            tempRefillInst = Instantiate(RefillTempPref);
            tempRefillInst.IngredientType = IngredientType.Chip;
            tempRefillInst.transform.position = chiSpawn.transform.position;
        }
        if (hasShe <= 0)
        {
            tempRefillInst = Instantiate(RefillTempPref);
            tempRefillInst.IngredientType = IngredientType.Shell;
            tempRefillInst.transform.position = sheSpawn.transform.position;
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
