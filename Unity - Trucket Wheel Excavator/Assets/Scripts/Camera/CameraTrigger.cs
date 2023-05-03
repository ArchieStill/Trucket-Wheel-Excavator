using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public bool isPlayer = true;

    private void Awake()
    {
        liveCam = Camera.allCameras[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        if (other == PlayerCollider && (Input.GetKey(KeyCode.E)) && isPlayer)
        {
            isPlayer = false;
            Debug.Log("Hello");
            triggeredCam.enabled = true;
            liveCam.enabled = false;

            liveCam = Camera.allCameras[0];
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        if (other == PlayerCollider)
        {
            triggeredCam.enabled = false;
            liveCam.enabled = true;

            liveCam = Camera.allCameras[0];
        }
    }*/
    

    public Camera triggeredCam;
    public Camera liveCam;
}
