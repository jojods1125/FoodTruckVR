using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private GameObject toDelete;

    // Fixed update is for physics updates regardless of framerate, should fix things skipping the trigger
    void FixedUpdate()
    {
        if (toDelete != null)
        {
            Destroy(toDelete);
        }
    }

    void OnTriggerStay(Collider objectCollide) //OnTriggerStay is more robust than plainly using OnTriggerEnter
    {
        //ideally use a public array that can be modified on the prefab
        if (objectCollide.CompareTag("Taco") || objectCollide.CompareTag("ChipBowl") || objectCollide.CompareTag("Refill") || objectCollide.CompareTag("Deletable") || objectCollide.CompareTag("Cash"))
        {
            //kill object
            toDelete = objectCollide.gameObject;

        }
    }
}
