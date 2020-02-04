using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Rigidbody level;
    public float speed = 600;
    public float f = 1;
    public float time = 30;
    // Start is called before the first frame update
    void Start()
    {
        level.AddForce(-speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time < 0) {
            level.transform.position = new Vector3(-40, 0, -.003f);
            //level.AddForce(-speed, 0, 0);
            time = 9;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
