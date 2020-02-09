using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_awning : MonoBehaviour
{
    Animator m_Animator;

    public GameObject handle;

    private bool actuating = false;
    public bool open = false;

    //public float handleAngles = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Animator from your GameObject
        m_Animator = GetComponent<Animator>();

        if (open)
        {
            openAwning();
        }
    }

    public void openAwning()
    {
        m_Animator.Play("Opening");
        open = true;
    }
    public void closeAwning()
    {
        m_Animator.Play("Closing");
        open = false;
    }
    public void breakAwning()
    {
        m_Animator.Play("Closing_Broken");
        open = false;
    }
    // Update is called once per frame
    private void Update()
    {
        //handleAngles = handle.transform.rotation.eulerAngles.x;

        //hardcoding angles cause idk a better way
        if (handle.transform.rotation.eulerAngles.x > 270 && handle.transform.rotation.eulerAngles.x < 290 && !open && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("CLOSED"))
        {
            openAwning();
            open = true; //setting this here because otherwise it gets stuck open or closed with the per frame check

        }

        if (handle.transform.rotation.eulerAngles.x > 20 && handle.transform.rotation.eulerAngles.x < 45 && open && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("OPEN"))
        {
            closeAwning();
            open = false;
        }

        //Press the space key to play the "Jump" state
        if (Input.GetKey(KeyCode.G))
        {
            openAwning();
        }
        if (Input.GetKey(KeyCode.T))
        {
            closeAwning();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            breakAwning();
        }
    }
}
