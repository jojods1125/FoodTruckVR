using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public GameObject spawnLocation;
    private GameObject spawnedItem;

    private int hasItem = 0;
    public int maxSpawned = 3;
    private bool itemPresence = false;

    public GameObject prefabToSpawn;

    public float spawnCooldown = 3;
    private float spawnTimeLeft= 0;

    public bool isStorange = false;
    public GameObject associatedDoor;
    //the isStorage is for checking if the associated door is open or not
    //TODO door angle checker similar to queso handle and awning

    private void Start()
    {
        
    }
    
    //Fixed update happens before collision events and regular update
    private void FixedUpdate()
    {
        itemPresence = false; //this will be set to true if the object stayed inside the trigger
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == prefabToSpawn) //This doesnt work
        //if (object.ReferenceEquals(other.gameObject, prefabToSpawn.gameObject)) //This didnt work also

        //Debug.Log(other.gameObject);
        //Debug.Log(spawnedItem.gameObject);

        if (other.gameObject == spawnedItem.gameObject) // this worked after casting the spawned item to its own variable
        {
            hasItem += 1;
        }
    }
    private void OnTriggerStay(Collider other) //using this to catch objects destroyed within the trigger that dont call OnTriggerExit 
    {
        if (other.gameObject == spawnedItem.gameObject)
        {
            itemPresence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == spawnedItem.gameObject)
        {
            hasItem -= 1;
        }
    }

    public void spawnItem()
    {
        //yeet

        ContainerManager containerManager = ContainerManager.SharedInstance;

        //get pickup container
        PickupIngredientContainer refillContainer = containerManager.RefillContainer;

        //Refill tempRefillInst;

        if (hasItem < maxSpawned || !itemPresence) //since it's OR itemPresence it will break the maxItems limit
        {
            //sorry Spicy, your container is cool and all but this is really all i need -Drumstick

            spawnedItem = Instantiate(prefabToSpawn) as GameObject; //Casting it to its own variable to count how many are in the trigger
            spawnedItem.transform.position = spawnLocation.transform.position;
            //spawnedItem.transform.rotation = spawnLocation.transform.rotation;

            

            //these checks are ech but it's what happens when bowls and shells are different types of objects from ingredients

            //if (foodPrefabToSpawn.GetComponent<FoodContainer>() != null)
            //{
            //    refillContainer.GetContainerModelByType(foodPrefabToSpawn.GetComponent<FoodContainer>().cont).transform.position = spawnLocation.transform.position;
            //}
            //else if(foodPrefabToSpawn.GetComponent<Refill>() != null)
            //{
            //    refillContainer.GetIngredientModelByType(foodPrefabToSpawn.GetComponent<Refill>().IngredientType).transform.position = spawnLocation.transform.position;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeLeft -= Time.deltaTime;
        if (spawnTimeLeft < 0)
        {
            spawnItem();
            spawnTimeLeft = spawnCooldown;
        }
    }
}
