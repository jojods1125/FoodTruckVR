using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Collider colliderBin;
    public OVRGrabbable GrabComp;

    private bool binActive = false;

    // Start is called before the first frame update
    void Start()
    {
        colliderBin.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabComp.isGrabbed == true)
        {
            colliderBin.enabled = true;
        }
        else if (GrabComp.isGrabbed == false)
        {
            colliderBin.enabled = false;
        }
    }
}
