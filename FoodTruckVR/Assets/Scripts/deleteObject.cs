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

    // Update is called once per frame
    void LateUpdate()
    {
        if (toDelete != null)
        {
            Destroy(toDelete);
        }
    }

    void OnTriggerEnter(Collider objectCollide)
    {
        //ideally use a public array that can be modified on the prefab
        if (objectCollide.CompareTag("Taco") || objectCollide.CompareTag("ChipBowl") || objectCollide.CompareTag("Refill") || objectCollide.CompareTag("Deletable"))
        {
            //kill object
            toDelete = objectCollide.gameObject;

        }
    }
}
