using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slosh : MonoBehaviour
{

    public Transform centerObject;
    public float radius = 15;

    private float timeLeftBIG = 10;
    private float timeLeftLITTLE = 5;

    public float bigSloshForce = 3.2f;
    public float littleSloshForce = 0.6f;

    public float initialBigSloshDelay = 10;

    public float bigSlosh_minTime = 15;
    public float bigSloch_maxTime = 30;

    public float littleSlosh_minTime = 0.5f;
    public float littleSlosh_maxTime = 1.75f;

    private void Start()
    {
        timeLeftBIG = initialBigSloshDelay;
        timeLeftLITTLE = littleSlosh_maxTime;
    }


    void randomForce(Vector3 center, float radius)
    {
        Rigidbody[] Bodies = GameObject.FindObjectsOfType<Rigidbody>();
        //Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < Bodies.Length)
        {

            //Rigidbody rigidBody = hitColliders[i].GetComponent<Rigidbody>();
            Rigidbody rigidBody = Bodies[i];
            if (rigidBody == null) {
                break;
            }
            transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), transform.eulerAngles.z);
            float speed = 200;
            Vector3 force = transform.forward;
            force = new Vector3(force.x, 1, force.z);
            rigidBody.AddForce(force * speed);
            i++;
        }
    }

    void bigSlosh(Vector3 center, float radius)
    {
        Rigidbody[] Bodies = GameObject.FindObjectsOfType<Rigidbody>();
        //Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < Bodies.Length)
        {

            //Rigidbody rigidBody = hitColliders[i].GetComponent<Rigidbody>();
            Rigidbody rigidBody = Bodies[i];
            if (rigidBody == null)
            {
                break;
            }
            transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), transform.eulerAngles.z);
            float speed = bigSloshForce * Random.Range(0.75f, 1.25f); //applying some variance
            Vector3 force = transform.forward;
            force = new Vector3(force.x, 1, force.z);
            rigidBody.AddForce(force * speed, ForceMode.Impulse); //Using impulse mode for more convincing physics
            i++;
        }
    }

    void littleSlosh(Vector3 center, float radius)
    {
        Rigidbody[] Bodies = GameObject.FindObjectsOfType<Rigidbody>();
        //Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < Bodies.Length)
        {

            //Rigidbody rigidBody = hitColliders[i].GetComponent<Rigidbody>();
            Rigidbody rigidBody = Bodies[i];
            if (rigidBody == null)
            {
                break;
            }
            transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), transform.eulerAngles.z);
            float speed = littleSloshForce * Random.Range(0.5f, 1.5f); //applying some variance
            Vector3 force = transform.forward;
            force = new Vector3(force.x, 1, force.z);
            rigidBody.AddForce(force * speed, ForceMode.Impulse); //Using impulse mode for more convincing physics
            i++;
        }
    }

    private void FixedUpdate()
    {

        this.timeLeftBIG -= Time.fixedDeltaTime;
        this.timeLeftLITTLE -= Time.fixedDeltaTime;
        if (this.timeLeftBIG < 0)
        {
            bigSlosh(centerObject.position, radius);
            this.timeLeftBIG = Random.Range(bigSlosh_minTime, bigSloch_maxTime);
            Debug.Log("Whoopsie Doodles");
        }
        if (this.timeLeftLITTLE < 0)
        {
            littleSlosh(centerObject.position, radius);
            this.timeLeftLITTLE = Random.Range(littleSlosh_minTime, littleSlosh_maxTime);
            //Debug.Log("bump in road");
        }

    }
}
