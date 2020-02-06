using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{

    public List<ParticleSystem> burnables;
    public float initialTime = 60;
    public float minTime = 20;
    public float maxTime = 40;
    private float timeLeft = 60;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < burnables.Count; i++) {
            ParticleSystem p = burnables[i];
            p.Stop();
        }

        timeLeft = initialTime;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            ParticleSystem thingOnFire = burnables[Random.Range(0, burnables.Count)];
            thingOnFire.Play(true);
            timeLeft = Random.Range(minTime, maxTime);
        }
    }

}
