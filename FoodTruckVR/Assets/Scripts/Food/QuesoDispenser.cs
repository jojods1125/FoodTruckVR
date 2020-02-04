using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoDispenser : MonoBehaviour
{
    public GameObject handle;

    public Ingredient spfpfpfpf;

    private float lastTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handle.transform.rotation.eulerAngles.x > 320 && Time.time - lastTime > 0.7)
        {
            Instantiate(spfpfpfpf, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            lastTime = Time.time;
        }
    }
}
