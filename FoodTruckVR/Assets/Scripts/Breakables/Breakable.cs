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
    /** Maps break points on the object and their chance to break */
    public struct BreakPoint
    {
        /** Auto-generated ID */
        [HideInInspector]
        public int ID;

        [Tooltip("The breakpoint transform on the object")] 
        public Transform Socket;

        [Tooltip("The break type that occurs at this spot")] 
        public BreakType BreakType;

        [Tooltip("The chance for the thing at this breakpoint to break/explode (higher weight = more likely)")]
        public int Weight;
    }

    [Tooltip("Name of this breakable object")]
    public string Name;

    [Tooltip("List of all breakpoints on the object, paired with their probability to break")]
    public List<BreakPoint> BreakPoints;

    [Tooltip("The chance for something on this thing to break/explode (higher weight = more likely)")]
    public int Weight;

    /** Total weight of the breakpoints attached to this object */
    private int _TotalWeight;

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
                Transform socket = breakPoint.Socket;

                switch(breakPoint.BreakType)
                {
                    case BreakType.BreakOff:
                        //detach child if child exists
                        if(socket.childCount > 0)
                        {
                            socket.DetachChildren();
                            return true;
                        }
                        break;
                }
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
                            return true;
                        }
                        break;
                }
            }
        }

        return false;
    }




}
