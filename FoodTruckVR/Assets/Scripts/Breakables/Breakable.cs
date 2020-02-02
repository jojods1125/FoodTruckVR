using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** All the different ways things can break in the game */
public enum BreakType
{
    BreakOff,
}

/** Attach to objects in game that have components that can break in some way */
public class Breakable : MonoBehaviour
{
    [Tooltip("Name of this breakable object")]
    public string Name;

    [Tooltip("The chance for something on this thing to break/explode (higher weight = more likely)")]
    public int Weight;

    [Tooltip("List of all breakpoints on the object, paired with their probability to break")]
    public List<BreakPoint> BreakPoints;

    /** Total weight of the breakpoints attached to this object */
    private int _TotalWeight;

    /** Tells if in its current state the object is broek */
    private bool _IsBroken;



    /** Initialize the ID's of the breakpoints and add up weights */
    public void Initialize()
    {
        for( int i = 0; i < BreakPoints.Count; i++)
        {
            BreakPoint bp = BreakPoints[i];
            bp.ID = i;
            _TotalWeight += bp.Weight;
        }
    }

    /** Choose something at random to break on this object */
    public bool BreakSomethingAtRandom()
    {
        int randomWeight = Random.Range(0, _TotalWeight) + 1;

        foreach(BreakPoint breakPoint in BreakPoints)
        {
            randomWeight -= breakPoint.Weight;

            if(randomWeight <= 0)
            {
                breakPoint.Break();
                _IsBroken = breakPoint.IsBroken;
                return true;
            }
        }

        return false;
    }

    /** Cause a breakpoint at the transform with matching ID */
    public bool Break(int inID)
    {
        foreach(BreakPoint breakPoint in BreakPoints)
        {
            if(breakPoint.ID == inID)
            {
                Transform socket = breakPoint.Socket;

                switch(breakPoint.BreakType)
                {
                    case BreakType.BreakOff:
                        //detach child if child exists
                        if(socket.childCount > 0)
                        {
                            socket.DetachChildren();
                            _IsBroken = breakPoint.IsBroken = true;
                            return true;
                        }
                        break;
                }
            }
        }

        return false;
    }
}
