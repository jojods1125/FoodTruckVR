using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_awning : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Animator from your GameObject
        m_Animator = GetComponent<Animator>();
    }

    public void openAwning()
    {
        m_Animator.Play("Opening");
    }
    public void closeAwning()
    {
        m_Animator.Play("Closing");
    }
    public void breakAwning()
    {
        m_Animator.Play("Closing_Broken");
    }
    // Update is called once per frame
    private void Update()
    {
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
