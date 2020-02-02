using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public List<ParticleSystem> burnables;
    public float time = 30;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < burnables.Count; i++) {
            ParticleSystem p = burnables[i];
            p.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            ParticleSystem thingOnFire = burnables[Random.Range(0, 4)];
            thingOnFire.Play(true);
            time = Random.Range(15, 35);
        }
    }

}
