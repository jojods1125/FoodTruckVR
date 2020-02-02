using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMat : MonoBehaviour
{
    
    public Material mat_beans;
    public MeshRenderer meshrender;

    public void NewOrder()
    {
        Material[] materials = meshrender.materials;
        materials[0] = mat_beans;

        meshrender.materials = materials;

    }

    

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NewOrder();
        }
    }
}
