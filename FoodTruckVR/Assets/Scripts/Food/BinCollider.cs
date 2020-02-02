using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollider : MonoBehaviour
{
    public GameObject ingredSpawn1;
    public GameObject ingredSpawn2;
    public GameObject ingredSpawn3;

    public Ingredient IngredTemp;

    void OnTriggerEnter (Collider refillCollide)
    {
        if (refillCollide.CompareTag("Refill"))
        {

            //temp vars for ingreds
            Ingredient IngredInst1;
            Ingredient IngredInst2;
            Ingredient IngredInst3;

            //create each ingredient
            IngredInst1 = Instantiate(IngredTemp, ingredSpawn1.transform) as Ingredient;
            IngredInst1.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;

            IngredInst2 = Instantiate(IngredTemp, ingredSpawn2.transform) as Ingredient;
            IngredInst2.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;

            IngredInst3 = Instantiate(IngredTemp, ingredSpawn3.transform) as Ingredient;
            IngredInst3.IngredientType = refillCollide.GetComponent<Refill>().IngredientType;

            //kill refill
            Destroy(refillCollide.gameObject);

        }
    }
}
