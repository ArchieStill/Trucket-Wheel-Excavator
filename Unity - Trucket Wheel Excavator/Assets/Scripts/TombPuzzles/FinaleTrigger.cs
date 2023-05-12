using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    public GameObject controlText;

    private void Awake()
    {
        liveCam = Camera.allCameras[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject TruckObject = GameObject.FindGameObjectWithTag("TWE");
        Collider TruckCollider = TruckObject.GetComponent<Collider>();
        if (other == TruckCollider)
        {
            triggeredCam.enabled = true;
            liveCam.enabled = false;
            controlText.SetActive(false);

            liveCam = Camera.allCameras[0];
            triggeredCam.GetComponent<AudioListener>().enabled = true;
        }
    }
}
