using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Transitions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TruckMovement truckMovement;
    
    public Camera triggeredCam;
    public Camera liveCam;
    public bool isClose = false;
    public GameObject PlayerCharacter;
    public Collider PlayerCollider;
    public GameObject TruckObject;
    public GameObject textObject;
    public GameObject driverObject;
    public GameObject smokeObject;
    public GameObject lightObject;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        TruckObject.GetComponent<AudioListener>().enabled = false;
        liveCam = Camera.allCameras[0];
        textObject.SetActive(false);
        driverObject.SetActive(false);
        smokeObject.SetActive(false);
        lightObject.SetActive(true);
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
                driverObject.SetActive(true);
                smokeObject.SetActive(true);
                lightObject.SetActive(false);
                PlayerCharacter.transform.parent = driverObject.transform;
                PlayerCharacter.GetComponent<AudioListener>().enabled = false;
                TruckObject.GetComponent<AudioListener>().enabled = true;
                triggeredCam.enabled = true;
                liveCam.enabled = false;
            }
            else if (truckMovement.isTruck)
            {
                truckMovement.isTruck = false;
                PlayerCharacter.SetActive(true);
                playerMovement.Enable();
                driverObject.SetActive(false);
                PlayerCharacter.transform.parent = null;
                PlayerCharacter.GetComponent<AudioListener>().enabled = true;
                TruckObject.GetComponent<AudioListener>().enabled = false;
                triggeredCam.enabled = false;
                liveCam.enabled = true;
                liveCam = Camera.allCameras[0];
                textObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!truckMovement.isTruck)
        {
            if (other == PlayerCollider)
            {
                isClose = true;
                textObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            isClose = false;
            textObject.SetActive(false);
        }
    }
}
