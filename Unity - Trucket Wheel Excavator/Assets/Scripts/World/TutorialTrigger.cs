using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public Collider PlayerCollider;
    public GameObject textObject;
    private bool tutorialActive = true;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        textObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tutorialActive)
        {
            if (other == PlayerCollider)
            {
                textObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            textObject.SetActive(false);
            tutorialActive = false;
        }
    }
}
