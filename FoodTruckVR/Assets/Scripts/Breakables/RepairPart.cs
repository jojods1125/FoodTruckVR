using UnityEngine;

public enum RepairPartType
{
    //the part is handled by the player and attached to what broke
    ReplacePart,
}

/** An item that is used to repair a break point */
public class RepairPart : MonoBehaviour
{
    [Tooltip("break point fixed by this repair part")] 
    public BreakPoint BreakPoint;

    /** Handle any extra stuff needed to be done upon repair */
    public virtual void Repair()
    {
        //Do nothing
    }
}
