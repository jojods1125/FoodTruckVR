using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherParticles : MonoBehaviour
{
    public ParticleSystem Extinguisher;
    public Rigidbody FireExt;
    public GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
        Extinguisher.Stop(true);
        collider.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (FireExt.GetComponent<OVRGrabbable>().isGrabbed) {
            Extinguisher.Play(true);
            collider.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<MeshCollider>().GetComponentInChildren<ParticleSystem>().Stop(true);
    }
}
