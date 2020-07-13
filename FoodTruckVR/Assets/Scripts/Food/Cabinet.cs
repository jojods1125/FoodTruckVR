using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public GameObject chiSpawn;
    public GameObject sheSpawn;

    int hasChi = 0;
    int hasShe = 0;

    public Ingredient RefillTempPref;

    public float refillCooldown = 3;
    private float refillCooldown_og = 3;

    private void Start()
    {
        refillCooldown_og = refillCooldown;
        refillCooldown = 0;
    }

    void OnTriggerEnter(Collider refillCollide)
    {

        switch (refillCollide.GetComponent<Ingredient>().IngredientType)
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

        switch (refillCollide.GetComponent<Ingredient>().IngredientType)
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
        ContainerManager containerManager = ContainerManager.SharedInstance;

        //get pickup container
        PickupIngredientContainer refillContainer = containerManager.InfiniteContainer;

        //Refill tempRefillInst;

        if (hasChi <= 0)
        {
            refillContainer.GetIngredientModelByType(IngredientType.Chip).transform.position = chiSpawn.transform.position;
            //tempRefillInst = Instantiate(RefillTempPref);
            //tempRefillInst.IngredientType = IngredientType.Chip;
            //tempRefillInst.transform.position = chiSpawn.transform.position;
        }
        if (hasShe <= 0)
        {
            GameObject shell = refillContainer.GetIngredientModelByType(IngredientType.Shell);
            shell.transform.position = sheSpawn.transform.position;
            //shell.transform.localScale = new Vector3(40,40,40);
            //tempRefillInst = Instantiate(RefillTempPref);
            //tempRefillInst.IngredientType = IngredientType.Shell;
            //tempRefillInst.transform.position = sheSpawn.transform.position;
        }
    }

    private void Update()
    {
        refillCooldown -= Time.deltaTime;
        if (refillCooldown < 0)
        {
            StorageFill();
            refillCooldown = refillCooldown_og;
        }
    }
}
