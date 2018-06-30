using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    private Transform selectedObject;

    
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.GetComponent<IRayCastable>() != null)
            {
                
                hit.transform.GetComponent<IRayCastable>().OnSelected();

                if ((hit.transform != selectedObject) && (selectedObject != null))
                {
                    selectedObject.GetComponent<IRayCastable>().OnReleased();
                }

                selectedObject = hit.transform;
            }
            else
            {
                if (selectedObject != null)
                {
                    if (selectedObject.GetComponent<IRayCastable>() != null)
                    {
                        selectedObject.GetComponent<IRayCastable>().OnReleased();
                    }
                }
                selectedObject = null;
            }
        }
        else
        {
            if (selectedObject != null)
            {
                if (selectedObject.GetComponent<IRayCastable>() != null)
                {
                    selectedObject.GetComponent<IRayCastable>().OnReleased();
                }
            }
            selectedObject = null;
        }
	}
}
