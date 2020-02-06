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

    // Update is called once per frame
    private void Update()
    {
        //Press the space key to play the "Jump" state
        if (Input.GetKey(KeyCode.G))
        {
            m_Animator.Play("Opening");
        }
        if (Input.GetKey(KeyCode.T))
        {
            m_Animator.Play("Closing");
        }
        if (Input.GetKey(KeyCode.Y))
        {
            m_Animator.Play("Closing_Broken");
        }
    }
}
