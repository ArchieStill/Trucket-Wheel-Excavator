using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDestroyed : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public GameObject TruckObject;
    public Collider wheelCollider;
    public TruckMovement truckMovement;
    public GameObject dirtMound;
    public float speed = 3f;
    public int moundsDestroyed = 0;

    private void Awake()
    {
        TruckObject = GameObject.FindGameObjectWithTag("TWE");
        wheelCollider = TruckObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float step = speed * Time.deltaTime;
        if (truckMovement.isSpinning)
        {
            dirtMound.transform.position = Vector3.MoveTowards(dirtMound.transform.position, endPos.transform.position, step);
        }
    }
}
