using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignTrigger : MonoBehaviour {

    public Material[] highlightMats;
    public bool TrackerInZone;

	// Use this for initialization
	void Start () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tracker")
        {
            GetComponent<MeshRenderer>().material = highlightMats[1];
            TrackerInZone = true;

            GetComponentInParent<AlignCalibrate>().CheckTriggers();

        }
    }


    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Tracker")
        {
            GetComponent<MeshRenderer>().material = highlightMats[0];
            TrackerInZone = false;

        }


    }

}
