using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalIngredient : Ingredient
{
    public bool CanGrab = true;

    private GameObject toDelete;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (toDelete != null)
        {
            Destroy(toDelete);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FoodContainer>() != null)
        {
            if (collision.gameObject.GetComponent<FoodContainer>().AddIngredient(this))
            {
                toDelete = gameObject;
            }
        } else
        {
            //Debug.Log("Failure to add");
        }
    }

}
