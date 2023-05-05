using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;

    public bool isClose = false;
    public PlayerMovement playerMovement;

    public GameObject PlayerCharacter;
    public Collider PlayerCollider;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        liveCam = Camera.allCameras[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            isClose = true;
            liveCam = Camera.allCameras[0];
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && isClose && playerMovement.getIsPlayer())
        {
            playerMovement.Disable();
            triggeredCam.enabled = true;
            liveCam.enabled = false;
            liveCam = Camera.allCameras[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
