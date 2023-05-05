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
            if (playerMovement.getIsPlayer() && isClose)
            {
                truckMovement.isTruck = true;
                playerMovement.Disable();
                PlayerCharacter.SetActive(false);
                triggeredCam.enabled = true;
                liveCam.enabled = false;
                Debug.Log("TRUCK");
            }
            else if (truckMovement.isTruck)
            {
                truckMovement.isTruck = false;
                PlayerCharacter.SetActive(true);
                playerMovement.Enable();
                triggeredCam.enabled = false;
                liveCam.enabled = true;
                liveCam = Camera.allCameras[0];
                Debug.Log("PLAYER");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*if (truckMovement.isTruck)
            {
                truckMovement.isTruck = false;
                PlayerCharacter.SetActive(true);
                // playerMovement.Enable();
                triggeredCam.enabled = false;
                liveCam.enabled = true;
                liveCam = Camera.allCameras[0];
                Debug.Log("PLAYER");
            }
            if (playerMovement.getIsPlayer() && isClose && other == PlayerCollider)
            {
                truckMovement.isTruck = true;
                // playerMovement.Disable();
                PlayerCharacter.SetActive(false);
                triggeredCam.enabled = true;
                liveCam.enabled = false;
                Debug.Log("TRUCK");
            }*/
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
