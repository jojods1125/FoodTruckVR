using System.Collections.Generic;
using UnityEngine;

public class BreakableManager : MonoBehaviour
{
    public static BreakableManager SharedInstance;

    [Tooltip("List of all breakable objects in the world. IF ITS NOT HERE ITS NOT GONNA BREAK")]
    [SerializeField]
    private List<Breakable> _AllBreakables;

    /** Total weight of all breakables in scene */
    private int _TotalWeight;

    /** Minimum amount of time between events of something breaking in the truck */
    public float MinTimeBetweenBreaks = 7;

    /** Maximum amount of time between events of something breaking in the truck */
    public float MaxTimeBetweenBreaks = 15;

    /** Initialize Systems */
    void Awake()
    {
        if(SharedInstance == null)
        {
           SharedInstance = this; 
        }

        foreach(Breakable breakable in _AllBreakables)
        {
            breakable.Initialize();
            _TotalWeight += breakable.Weight;
        }
    }

    /** Establish loop that handles stuff breaking */
    void Start()
    {
        float secondsTillBreak = GetNextTimeOfBreak();

        Invoke("BreakLoop", secondsTillBreak);
    }

    /** Return the amount of seconds till next call to break someting */
    private float GetNextTimeOfBreak()
    {
        float seconds = Random.Range(MinTimeBetweenBreaks, MaxTimeBetweenBreaks);

        return seconds;
    }

    /** Break something and schedule to break again in the future (always weighted) */
    private void BreakLoop()
    {
        BreakRandomObjectWeighted();

        float secondsTillBreak = GetNextTimeOfBreak();

        Invoke("BreakLoop", secondsTillBreak);
    }

    /** Choose a breakable to break at random */
    void BreakRandomObject()
    {
        int randomIndex = Random.Range(0, _AllBreakables.Count);

        _AllBreakables[randomIndex].BreakSomethingAtRandom();
    }

    /** Choose an object to break at random, considering the weights of the objects */
    void BreakRandomObjectWeighted()
    {
        int randomWeight = Random.Range(0, _TotalWeight) + 1;

        foreach(Breakable breakable in _AllBreakables)
        {
            randomWeight -= breakable.Weight;

            if(randomWeight <= 0)
            {
                bool success = breakable.BreakSomethingAtRandom();
                
                //If something broke, end and return. Otherwise, continue on to find something else to break
                if(success)
                {
                    return;
                }
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

    /** Break an object with matching name at its specific socket */
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

    /** If the breakable owns the mended point, tell it that it should check if its mended */
    public void NotifyBreakableOfRepair(BreakPoint inMendedPoint)
    {
        foreach(Breakable breakable in _AllBreakables)
        {
            if(breakable.ContainsBreakPoint(inMendedPoint) == true)
            {
                breakable.CheckIfRepaired();
                return;
            }
        }
    }
}
