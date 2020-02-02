using UnityEngine;

/** An item that is used to repair a break point */
public class RepairPart : MonoBehaviour
{
    [Tooltip("break point fixed by this repair part")] 
    public BreakPoint BreakPoint;

    [Tooltip("point of connection with the break point related to this object")] 
    public Transform Socket;
}
