using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherParticles : MonoBehaviour
{
    public ParticleSystem Extinguisher;
    public Rigidbody FireExt;
    // Start is called before the first frame update
    void Start()
    {
        Extinguisher = GetComponent<ParticleSystem>();
        FireExt = GetComponent<Rigidbody>();
        Extinguisher.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (FireExt.GetComponent<OVRGrabbable>().isGrabbed) {
            Extinguisher.Play();
        }
    }
}
