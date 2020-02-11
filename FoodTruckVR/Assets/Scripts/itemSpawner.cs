using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //needed for prefab schenanigans

public class itemSpawner : MonoBehaviour
{
    public GameObject spawnLocation;
    private GameObject spawnedItem;

    public bool autoSpawn = true;
    public int hasItem = 0;
    public int maxSpawned = 3;
    private bool itemPresence = false;

    public GameObject prefabToSpawn;

    public float spawnCooldown = 3;
    private float spawnTimeLeft= 0;

    //Door vars
    public bool isStorage = false;
    public GameObject associatedDoor;
    private bool doorOpen = false;
    private float doorBaseRot;
    //the isStorage is for checking if the associated door is open or not
    //TODO door angle checker similar to queso handle and awning

    //force vars
    public bool applyForce = false;
    public float forceMagnitude;
    public Vector3 forceDirection;
    //TODO this

    private void Start()
    {
        if (isStorage)
        {
            if (associatedDoor != null)
            {
                doorBaseRot = associatedDoor.transform.rotation.eulerAngles.y; //get the default closed angles (y is global y)
            }
            else
            {
                Debug.Log("Associated Door not Specified!!!!!");
            }
            
        }
    }
    
    //Fixed update happens before collision events and regular update
    private void FixedUpdate()
    {
        itemPresence = false; //this will be set to true if the object stayed inside the trigger
    }

    private void OnTriggerStay(Collider other) //using this to catch objects destroyed within the trigger that dont call OnTriggerExit 
    {
        if (other.name == prefabToSpawn.name)
        {
            itemPresence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject == prefabToSpawn) //This doesnt work
        //if (object.ReferenceEquals(other.gameObject, prefabToSpawn.gameObject)) //This didnt work also
        //if (other.gameObject == spawnedItem.gameObject) //This also did not work

        //Debug.Log(other.name);
        //Debug.Log(prefabToSpawn.name);
        //Debug.Log("something left the trigger");

        if (other.name == prefabToSpawn.name) //holy crap it was impossible to find the solution to this AND IT WAS SO SIMPLEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        {
            hasItem -= 1;
            //Debug.Log("removing 1 item" + other.gameObject);
        }
    }

    public void checkSpawn()
    {
        if (hasItem < maxSpawned )// || !itemPresence) //since it's OR itemPresence it will break the maxItems limit
        {
            if (isStorage)
            {
                if (!doorOpen)
                {
                    spawnItem();
                }
            }
            else
            {
                spawnItem();
            }
        }
    }

    public void spawnItem()
    {
        //yeet
        //sorry Spicy, your container is cool and all but this is really all i need -Drumstick
        //spawnedItem = PrefabUtility.InstantiatePrefab(prefabToSpawn.gameObject as GameObject) as GameObject; //uhhhhhhhhhhhhhhhh
        spawnedItem = Instantiate(prefabToSpawn) as GameObject; //Casting it to its own variable to count how many are in the trigger
        spawnedItem.name = prefabToSpawn.name; //stupid stupid stupid stupid stupid stupid stupid stupid stupid stupid stupid 

        if (spawnLocation != null)
        {
            spawnedItem.transform.position = spawnLocation.transform.position;
        }
        else
        {
            Debug.Log("spawnLocation not Set! Prefab spawns center of cube mesh!");
            spawnedItem.transform.position = this.transform.position; //put the object at the cube mesh center if a spawn location is not specified
        }

        hasItem += 1;

        //no rotation unti theres a better way of adding to the prefabs local rotation
        //spawnedItem.transform.rotation = spawnLocation.transform.rotation;

        if (applyForce)
        {
            spawnedItem.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isStorage)
        {
            //Debug.Log(associatedDoor.transform.rotation.eulerAngles.y - doorBaseRot);

            float deltaRot = Mathf.Abs(associatedDoor.transform.rotation.eulerAngles.y - doorBaseRot);

            if ( deltaRot < 2 || deltaRot > 358) //if the delta between the start angle and current angle is less than 2 degrees closed tolerance
            {
                doorOpen = false; //setting this here because otherwise it gets stuck open or closed with the per frame check
                //Debug.Log("door is closed");

            }
            else
            {
                doorOpen = true;

                //Debug.Log("door is open");
            }
        }

        if (autoSpawn) //dont bother updating the time variable if we dont have to
        {
            spawnTimeLeft -= Time.deltaTime;
            if (spawnTimeLeft < 0)
            {
                checkSpawn();
                spawnTimeLeft = spawnCooldown;
            }
        }
        
    }
}
