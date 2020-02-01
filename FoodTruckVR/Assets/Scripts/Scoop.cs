using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scoop : MonoBehaviour
{
    public GameObject child;
    // Update is called once per frame
    void Update()
    {
        if (child.transform.position.y < gameObject.transform.position.y)
        {
            Debug.Log("Drop stuff");
        }
        Debug.Log("Don't");
    }

}