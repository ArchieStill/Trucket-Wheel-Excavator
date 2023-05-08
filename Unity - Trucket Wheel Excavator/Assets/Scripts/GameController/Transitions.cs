using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TruckMovement truckMovement;
    
    public Camera triggeredCam;
    public Camera liveCam;
    public bool isClose = false;
    public GameObject PlayerCharacter;
    public Collider PlayerCollider;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        liveCam = Camera.allCameras[0];
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerMovement.GetIsPlayer() && isClose)
            {
                truckMovement.isTruck = true;
                playerMovement.Disable();
                PlayerCharacter.SetActive(false);
                triggeredCam.enabled = true;
                liveCam.enabled = false;
            }
            else if (truckMovement.isTruck)
            {
                truckMovement.isTruck = false;
                PlayerCharacter.SetActive(true);
                playerMovement.Enable();
                triggeredCam.enabled = false;
                liveCam.enabled = true;
                liveCam = Camera.allCameras[0];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            isClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            isClose = false;
        }
    }
}
