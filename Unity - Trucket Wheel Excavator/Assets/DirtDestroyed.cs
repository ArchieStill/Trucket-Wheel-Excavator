using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDestroyed : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public GameObject wheelCollider;
    public TruckMovement truckMovement;
    public float speed = 3f;

    private void Awake()
    {
        wheelCollider.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float step = speed * Time.deltaTime;
        if (other == wheelCollider)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
        }
    }
}
