using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public Collider PlayerCollider;
    public GameObject TruckObject;
    public Collider TruckCollider;
    public GameObject textObject;

    private void Awake()
    {
        textObject.SetActive(false);
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        TruckObject = GameObject.FindGameObjectWithTag("TWE");
        TruckCollider = TruckObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider || other == TruckCollider)
        {
            textObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider || other == TruckCollider)
        {
            textObject.SetActive(false);
        }
    }
}
