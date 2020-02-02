using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scoop : FoodContainer
{
    public GameObject child;
    // Update is called once per frame
    public IngredientType Scoopee;

    public GameObject ingredSpawn1;
    public Ingredient IngredTemp;

    //Mesh for switching
    public Mesh activeMesh1;
    public Mesh activeMesh2;
    public Ingredient dropMe;
    public Mesh currentMesh;
    //public MeshFilter mesh = ladle_full;

    public void Update()
    {

        if (child.transform.position.y < gameObject.transform.position.y && Scoopee != IngredientType.None)
        {
            dropMe = Instantiate(IngredTemp, ingredSpawn1.transform.position, new Quaternion(0,0,0,0));
            
            dropMe.IngredientType = Scoopee;

            Scoopee = IngredientType.None;

            currentMesh = this.GetComponent<MeshFilter>().sharedMesh;
            if (currentMesh != activeMesh1)
            {
                currentMesh = activeMesh1;
                this.GetComponent<MeshFilter>().mesh = currentMesh;
            }

            //Debug.Log("Dropped");
        }
    }
}