using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScaling : MonoBehaviour
{
    public float startSize = 1f;
    public float minSize = 0f;
    public float maxSize = 6f;

    public float speed = 15.0f;

    private Vector3 targetScale;
    private Vector3 baseScale;
    private float currScale;
    private Vector3 actualScale;

    private bool pulseActive;
    private bool pulseCont;
    private float pulseMultiplyer;

    void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        actualScale = transform.localScale; //since the currscale is unchanging while it actually changes scale


        //return back to the currscale it started with before the pulse
        if (pulseActive && Mathf.Abs(actualScale.magnitude - targetScale.magnitude) / 100 <= 0.02f) //2% tolerance since lerp isnt perfect (OMG IT TOO ME SO LONG TO FIGURE THIS OUT -Drumstick)
        {
            targetScale = baseScale * currScale;
            pulseActive = false;
        }
        //reverse in case of continuous pulse
        if (!pulseActive && pulseCont && Mathf.Abs(actualScale.magnitude - targetScale.magnitude) / 100 <= 0.02f)
        {
            targetScale = baseScale * pulseMultiplyer;
            pulseActive = true;
        }

        // If you don't want an eased scaling, replace the above line with the following line
        //   and change speed to suit:
        //transform.localScale = Vector3.MoveTowards (transform.localScale, targetScale, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeSize(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeSize(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pulseSize_once(0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pulseSize_once(1.2f);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            pulseSize_continous(1.2f);
        }
    }

    public void ChangeSize(bool bigger)
    {
        pulseActive = false; //prevent it from getting stuck
        pulseCont = false;

        if (bigger)
        {
            currScale++;
        }
        else
        {
            currScale--;
        }

        currScale = Mathf.Clamp(currScale, minSize, maxSize + 1);

        targetScale = baseScale * currScale;
    }

    public void ChangeSizeTo(float newSize)
    {
        pulseActive = false; //prevent it from getting stuck
        pulseCont = false;

        currScale = Mathf.Clamp(newSize, minSize, maxSize);

        targetScale = baseScale * currScale;
    }

    //Quickly go to the target scale and back to the starting size.
    public void pulseSize_once(float target_multiplyer)
    {
        pulseMultiplyer = target_multiplyer;

        targetScale = baseScale * pulseMultiplyer;
        pulseActive = true;
        pulseCont = false;
    }
    public void pulseSize_continous(float target_multiplyer)
    {
        pulseMultiplyer = target_multiplyer;

        targetScale = baseScale * pulseMultiplyer;
        pulseActive = true;
        pulseCont = true;
    }
}
