using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoDispenser : MonoBehaviour
{
    public GameObject handle;

    public Ingredient ingredientToDispense;

    private float lastTime = 0;

    public float dispenseTime = 0.5f;
    
    //public float handleAngles = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //handleAngles = handle.transform.rotation.eulerAngles.x;

        if (handle.transform.rotation.eulerAngles.x > 0 && handle.transform.rotation.eulerAngles.x < 90 && Time.time - lastTime > dispenseTime)
        {
            Instantiate(ingredientToDispense, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            lastTime = Time.time;
        }
    }
}
