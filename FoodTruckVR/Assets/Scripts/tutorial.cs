using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public Slosh sloshRef;
    public FireManager fireRef;
    public BreakableManager breakableRef;
    public script_awning awning;

    public GameObject associatedCustomer;
    public GameObject associatedUI;

    // Start is called before the first frame update
    void Start()
    {
        //Todo: make this an array somehow
        sloshRef.enabled = false;
        fireRef.enabled = false;
        breakableRef.enabled = false;

        associatedCustomer.SetActive(false);

        associatedUI.SetActive(true);
    }

    public void endTutorial()
    {
        sloshRef.enabled = true;
        fireRef.enabled = true;
        breakableRef.enabled = true;

        associatedCustomer.SetActive(true);

        //do scaling on each tile individually
        LerpScaling[] LerpList = associatedUI.GetComponentsInChildren<LerpScaling>();

        foreach (LerpScaling ls in LerpList)
        {
            ls.ChangeSizeTo(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (awning.open)
        {
            endTutorial();
        }   
    }
}
