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
            Debug.Log("ADD CHEESE YOU FOOL");
            if (collision.gameObject.GetComponent<FoodContainer>().AddIngredient(this))
            {
                Destroy(gameObject);
            }
        } else
        {
            Debug.Log("Failure");
        }
    }

}
