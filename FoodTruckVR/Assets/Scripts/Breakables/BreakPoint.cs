using UnityEngine;

 /** Maps break points on the object and their chance to break */
public class BreakPoint : MonoBehaviour
{
    /** Auto-generated ID */
    [HideInInspector]
    public int ID;

    /** Tells if the object is currently broken at this point */
    [HideInInspector]
    public bool IsBroken;

    [Tooltip("The breakpoint transform on the object")] 
    public Transform Socket;

    [Tooltip("The break type that occurs at this spot")] 
    public BreakType BreakType;

    [Tooltip("The chance for the thing at this breakpoint to break/explode (higher weight = more likely)")]
    public int Weight;

    /** Check if it belongs to the part that repairs this object. If so, attach back to this breakpoint */
    private void OnCollisionEnter(Collision collision)
    {
        //Not broken? Don't care at all
        if(IsBroken == false)
        {
            return;
        }

        RepairPart repairPart = collision.gameObject.GetComponent<RepairPart>();

        //not a repair part? ignore
        if (repairPart == null)
        {
            return;
        }

        //check if this repair part is meant to fix this breakpoint
        if(ReferenceEquals(repairPart.BreakPoint, this) == true)
        {
            Debug.Log("Repair");
            Repair(repairPart);
        }
    }

    /** Break it */
    public void Break()
    {
        switch(BreakType)
        {
            //detach child if child exists
            case BreakType.BreakOff:
                if(Socket.childCount > 0)
                {
                    Socket.DetachChildren();
                    IsBroken = true;
                }
                break;
        }
    }

    /** Repair based on the style of break we have here */
    private void Repair(RepairPart inRepairPart)
    {
        switch(BreakType)
        {
            case BreakType.BreakOff: //attach the repair part back on
                //TODO -- fix
            break;
        }
    }
}
