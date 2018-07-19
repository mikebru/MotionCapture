using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class AlignCalibrate : MonoBehaviour {

    public AlignTrigger[] childTriggers;
    public VRIKCalibrationController calibrate;

    public UnityEvent OnCalibration;

    // Use this for initialization
    void Start () {

        childTriggers = GetComponentsInChildren<AlignTrigger>();

		if (calibrate == null) {
			calibrate = FindObjectOfType<VRIKCalibrationController> ();
		}

	}

    public void CheckTriggers()
    {
        int activatedTriggers = 0;

        for(int i=0; i< childTriggers.Length; i++)
        {

            if(childTriggers[i].TrackerInZone == true)
            {
                activatedTriggers += 1;
            }

        }

        if (activatedTriggers == childTriggers.Length)
        {
            for (int i = 0; i < childTriggers.Length; i++)
            {
                childTriggers[i].gameObject.SetActive(false);
            }

            OnCalibration.Invoke();

            calibrate.Calibrate();
        }

    }


}
