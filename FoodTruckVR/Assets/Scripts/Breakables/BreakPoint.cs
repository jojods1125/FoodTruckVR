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
    private void OnTriggerEnter(Collider collision)
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

        Debug.Log("collision on breakpoint called with a repair part");


        //check if this repair part is meant to fix this breakpoint
        if(ReferenceEquals(repairPart.BreakPoint, this) == true)
        {
            Debug.Log("Repair with valid part");
            Repair(collision);
        }
    }

    /** Break it */
    public void Break()
    {
        Debug.Log("break on breakpoint called");
        switch(BreakType)
        {
            //detach child if child exists
            case BreakType.BreakOff:
                if(Socket.childCount > 0)
                {
                    Transform brokenPart = Socket.GetChild(0);

                    //get the rigidbody part + set its values so that it obeys normal physics
                    Rigidbody rigidBody = brokenPart.GetComponentInParent<Rigidbody>();

                    rigidBody.isKinematic = false;
                    rigidBody.useGravity = true;

                    Socket.DetachChildren();
                    IsBroken = true;
                }
                break;
        }
    }

    /** Repair based on the style of break used */
    private void Repair(Collider inCollision)
    {
        switch(BreakType)
        {
            //attach the repair part back on
            case BreakType.BreakOff:
                //now that we know type, get a replace part repair part
                RepairPartReplace repairPart = inCollision.gameObject.GetComponent<RepairPartReplace>();
                Transform partTransform = repairPart.gameObject.transform;
                partTransform.parent = Socket;
                partTransform.localPosition = Vector3.zero;
                Rigidbody rigidBody = repairPart.GetComponentInParent<Rigidbody>();
                rigidBody.isKinematic = true;
                rigidBody.useGravity = false;
                //let repair part take care of extra steps
                repairPart.Repair(); 
                break;
        }

        IsBroken = false;
        BreakableManager.SharedInstance.NotifyBreakableOfRepair(this);
    }
}
