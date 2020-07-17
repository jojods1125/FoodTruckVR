using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatDecal_script : MonoBehaviour
{
    // Use this for initialization
    public GameObject decalPrefab;
    //public float raydistance = 0.01f;
    private bool alreadyHit = false;
    public bool destroyOnHit = true;

    private GameObject toDelete;
    private GameObject spawnedDecal;

    void Start()
    {

    }

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    RaycastHit hit;
    //    //if (Physics.Raycast(transform.position, -transform.forward, out hit, raydistance))
    //    if (Physics.SphereCast(transform.position, raydistance, -transform.up, out hit, raydistance) && !alreadyHit)
    //    {
    //        //Quaternion rot = Quaternion.LookRotation(-hit.normal);
    //        Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
    //        Instantiate(quad, hit.point + hit.normal * 0.01f, rot);
    //        Debug.Log(hit.normal);

    //        alreadyHit = true;
    //    }

    //    //clone = Instantiate(quad, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
    //    //Destroy(clone.gameObject, 5);
    //    //clone.transform.parent = hit.transform;

    //    Debug.DrawRay(transform.position, -transform.up * raydistance, Color.green);
    //}

    private void OnCollisionEnter(Collision info)
    {
        // find collision point and normal. You may want to average over all contacts
        var point = info.contacts[0].point;
        var dir = -info.contacts[0].normal; // you need vector pointing TOWARDS the collision, not away from it
                                            // step back a bit
        point -= dir;
        RaycastHit hitInfo;
        // cast a ray twice as far as your step back. This seems to work in all
        // situations, at least when speeds are not ridiculously big


        if ((info.gameObject.GetComponent<FoodContainer>() == null || info.gameObject.GetComponent<PhysicalIngredient>() == null) && info.gameObject.tag != "MeatProof") //kinda messy like this, but prevents spawning decals on food
        {
            if (info.gameObject.tag == "Taco")
            {
                return;
            }

            if (!alreadyHit && info.collider.Raycast(new Ray(point, dir), out hitInfo, 2))
            {
                // this is the collider surface normal
                var normal = hitInfo.normal;
                // this is the collision angle
                // you might want to use .velocity instead of .forward here, but it 
                // looks like it's already changed due to bounce in OnCollisionEnter
                var angle = Vector3.Angle(-transform.forward, normal);

                Quaternion rot = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

                rot *= Quaternion.Euler(Vector3.up * Random.Range(0, 360)); //apply random rotation

                float offset = Random.Range(0.0015f, 0.002f); //the offset is to prevent z-fighting between the surface and overlapping decals

                spawnedDecal = Instantiate(decalPrefab, hitInfo.point + hitInfo.normal * offset, rot) as GameObject;

                spawnedDecal.transform.SetParent(info.gameObject.transform); //so that it doesnt float midair for things that move

                Debug.Log(hitInfo.normal);

                alreadyHit = true; //make sure it only makes one decal
            }

            //delete self after hitting something
            if (alreadyHit && destroyOnHit)
            {
                //NOTE these extra checks and delays might not be necessary if we are already checking if the collision object had a foodcontainer

                gameObject.GetComponent<MeshRenderer>().enabled = false; //hide the mesh render to mask the delay in gameobject destruction
                Destroy(gameObject, 0.25f); //0.25 sec delay to prevent conflict with physical ingredient (gross solution but it works)


                Destroy(spawnedDecal, 15.0f); //delete spawned decal after 15 seconds (it's cool this still works even though this gameobject is gone already)
            }
        }
    }
}
