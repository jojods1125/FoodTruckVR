using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scoop : MonoBehaviour
{
    public GameObject child;
    // Update is called once per frame
    public IngredientType Scoopee;

    public GameObject ingredSpawn1;
    public Ingredient IngredTemp;
    public void Update()
    {
        if (child.transform.position.y < gameObject.transform.position.y && Scoopee != IngredientType.None)
        {
            Ingredient dropped;
            dropped = Instantiate(IngredTemp, ingredSpawn1.transform) as Ingredient;
            dropped.IngredientType = Scoopee;
            Scoopee = IngredientType.None;
            
            Debug.Log("Dropped");
            //Destroy(ingredSpawn1, .5f);
        }
    }

}