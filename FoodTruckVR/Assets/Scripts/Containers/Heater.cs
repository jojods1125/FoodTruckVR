using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    public IngredientType ingred;

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.GetComponent<Scoop>() != null)
        { 
            other.GetComponent<Scoop>().Scoopee = ingred;
            Debug.Log("Scooped");
            //other.GetComponent<MeshFilter>().mesh = ladle_full;
            
        }
    }
}
