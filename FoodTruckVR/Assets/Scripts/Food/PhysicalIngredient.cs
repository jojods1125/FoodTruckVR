using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalIngredient : Ingredient
{
    public bool CanGrab = true;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FoodContainer>() != null)
        {
            collision.gameObject.GetComponent<FoodContainer>().AddIngredient(this);
        } else
        {
            Debug.Log("Failure");
        }
    }

}
