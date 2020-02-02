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
    private int _TotalWeight = 0;

    /** Tells if in its current state the object is broek */
    private bool _IsBroken;

    public bool IsBroken
    {
        get { return _IsBroken; }
    }

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

    public bool ContainsBreakPoint(BreakPoint inBreakPoint)
    {
        return BreakPoints.Contains(inBreakPoint);   
    }

    /** Choose something at random to break on this object */
    public bool BreakSomethingAtRandom()
    {
        Debug.Log($"Break something at random called on {Name}");

        int randomWeight = Random.Range(0, _TotalWeight) + 1;

        foreach(BreakPoint breakPoint in BreakPoints)
        {
            randomWeight -= breakPoint.Weight;

            if(randomWeight <= 0 && breakPoint.IsBroken == false)
            {
                breakPoint.Break();
                _IsBroken = (_IsBroken || breakPoint.IsBroken);
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

    /** Check all break points. If all are repaired (not broken), this object is repaired */
    public void CheckIfRepaired()
    {
        bool stillBroken = false;

        foreach(BreakPoint breakPoint in BreakPoints)
        {
            stillBroken = !stillBroken && breakPoint.IsBroken;
        }

        _IsBroken = stillBroken;
    }
}
