using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slosh : MonoBehaviour
{

    public Transform centerObject;
    public float radius = 1000;
    private float timeLeft = 5;
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

    private void FixedUpdate()
    {

        this.timeLeft -= Time.fixedDeltaTime;
        if (this.timeLeft < 0)
        {
            randomForce(centerObject.position, radius);
            this.timeLeft = Random.Range(0, 15);
            Debug.Log("Whoopsie Doodles");
        }

    }
}
