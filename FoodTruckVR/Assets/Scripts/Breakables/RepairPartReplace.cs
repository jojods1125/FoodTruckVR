using UnityEngine;

/** Repairs a breakable by touching this part to the breakpoint */
public class RepairPartReplace : RepairPart
{
    private Vector3 targetLocalPosition;
    private Quaternion targetLocalRotation;

    void Awake()
    {
        if(gameObject == null)
            return;

        targetLocalPosition = gameObject.transform.localPosition;
        targetLocalRotation = gameObject.transform.localRotation;

        Debug.Log("local pos " + targetLocalPosition);
        Debug.Log("local rot " + targetLocalRotation);
    }

    /** Handle special case for this part, where we snap it to the proper position and rotation on the object */
    public override void Repair()
    {
        gameObject.transform.localPosition = targetLocalPosition;
        gameObject.transform.localRotation = targetLocalRotation;

        //check ovr values
        OVRGrabbable grabbableComponent = gameObject.GetComponent<OVRGrabbable>();

        //NO TIME
        grabbableComponent.SetNewKinematic(true);
    }
}
