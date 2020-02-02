using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBox : MonoBehaviour
{
    public void NewOrder()
    {
        int tempRand = Random.Range(1, 10);
        Debug.Log(tempRand.ToString());
        //if(tempRand)
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NewOrder();
        }
    }
}
