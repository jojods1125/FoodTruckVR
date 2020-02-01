using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableManager : MonoBehaviour
{
    [Tooltip("List of all breakable objects in the world. IF ITS NOT HERE ITS NOT GONNA BREAK")]
    [SerializeField]
    List<Breakable> _AllBreakables;

    /** Total weight of all breakables in scene */
    private int _TotalWeight;

    /** Initialize Systems */
    void Awake()
    {
        foreach(Breakable breakable in _AllBreakables)
        {
            breakable.Initialize();
            _TotalWeight += breakable.Weight;
        }
    }

    /** Choose a breakable to break at random */
    void BreakRandomObject()
    {
        int randomIndex = Random.Range(0, _AllBreakables.Count);

        _AllBreakables[randomIndex].BreakSomethingAtRandom();
    }

    /** Choose an object to break at random, considering the weights of the objects*/
    void BreakRandomObjectWeighted()
    {
        int randomWeight = Random.Range(0, _TotalWeight) + 1;

        foreach(Breakable breakable in _AllBreakables)
        {
            randomWeight -= breakable.Weight;

            if(randomWeight <= 0)
            {
                breakable.BreakSomethingAtRandom();
                return;
            }
        }
    }

    /** Break something at random on the object with the given name */
    void BreakObjectByNameRandomly(string inName)
    {
        foreach(Breakable breakable in _AllBreakables)
        {
            if(breakable.Name.Equals(inName) == true)
            {
                breakable.BreakSomethingAtRandom();
            }
        }
    }

    /** Break an object with matching name at the specific socket */
    void BreakSpecificPointOnObject(string inName, int inSocketID)
    {
        foreach(Breakable breakable in _AllBreakables)
        {
            if(breakable.Name.Equals(inName) == true)
            {
                breakable.Break(inSocketID);
            }
        }
    }
}
