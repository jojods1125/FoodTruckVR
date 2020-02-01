using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollider : MonoBehaviour
{
    public GameObject ingredSpawn1;
    public GameObject ingredSpawn2;
    public GameObject ingredSpawn3;

    public Ingredient IngredTempPref;

    void OnTriggerEnter (Collider refillCollide)
    {
        if (refillCollide.CompareTag("Refill"))
        {
            //Debug.Log("refilled");

            //temp vars for ingreds
            Ingredient IngredInst1;
            Ingredient IngredInst2;
            Ingredient IngredInst3;

            //create each ingredient
            IngredInst1 = Instantiate(IngredTempPref);
            IngredInst1.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            IngredInst1.transform.position = ingredSpawn1.transform.position;

            IngredInst2 = Instantiate(IngredTempPref);
            IngredInst2.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            IngredInst2.transform.position = ingredSpawn2.transform.position;

            IngredInst3 = Instantiate(IngredTempPref);
            IngredInst3.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;
            IngredInst3.transform.position = ingredSpawn3.transform.position;

            //kill refill
            Destroy(refillCollide.gameObject);

        }
    }
}
