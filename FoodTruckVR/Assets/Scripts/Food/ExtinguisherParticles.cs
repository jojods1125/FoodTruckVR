using UnityEngine;

public class ExtinguisherParticles : MonoBehaviour
{
    public ParticleSystem Extinguisher;
    public Collider particleCollider;
    public OVRGrabbable GrabComp;

    private bool _EffectPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        Extinguisher.Stop(true);
        particleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_EffectPlaying == false && GrabComp.isGrabbed == true)
        {
            Extinguisher.Play(true);
            particleCollider.enabled = true;
            _EffectPlaying = true;
        }
        else if(_EffectPlaying == true && GrabComp.isGrabbed == false)
        {
            Extinguisher.Stop();
            particleCollider.enabled = false;
            _EffectPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            //the ? mark offers a null check
            other.GetComponent<ParticleSystem>()?.Stop();
        }
    }
}
