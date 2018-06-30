using UnityEngine;
using System.Collections;
using Vuforia;

public class BackgroundOff : MonoBehaviour
{

    private bool mBackgroundWasSwitchedOff = false;

    // Update is called once per frame
    void Update()
    {
        if (!mBackgroundWasSwitchedOff)
        {
            BackgroundPlaneBehaviour bgPlane = GetComponentInChildren<BackgroundPlaneBehaviour>();
            if (bgPlane)
            {
                if (bgPlane.gameObject.activeSelf == true)
                {                 
                    // switch it off
                    bgPlane.gameObject.SetActive(false);
                }
            }
            mBackgroundWasSwitchedOff = true;
        }
    }
}