using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Rigidbody level;
    public float speed = 600;
    public float f = 1;
    public float time = 30;

    float time_og = 30;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        level.AddForce(-speed, 0, 0);
        time_og = time;
        originalPos = level.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time < 0) {
            level.transform.position = originalPos; //fixed
            //level.transform.position = new Vector3(-40, 0, -.003f);
            //level.AddForce(-speed, 0, 0);
            time = time_og;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
