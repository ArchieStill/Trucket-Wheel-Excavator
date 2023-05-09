using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRigidbody : MonoBehaviour
{
    public Rigidbody cubeBody;
    public GameObject wheelCollider;
    public TruckMovement truckMovement;

    void Awake()
    {
        cubeBody = GetComponent<Rigidbody>();
        cubeBody.isKinematic = true;
    }

    void Update()
    {
        if (truckMovement.isSpinning)
        {
            cubeBody.isKinematic = false;
        }
        else
        {
            cubeBody.isKinematic = true;
        }
    }
}
