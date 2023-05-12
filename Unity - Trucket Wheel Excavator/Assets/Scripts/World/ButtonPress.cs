using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool isPressed = false;
    public GameObject PlayerCharacter;
    public Collider PlayerCollider;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            isPressed = true;
        }
    }
}
