using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTheTrucky : MonoBehaviour
{
    private GameObject truck;

    private void Awake()
    {
        truck = GameObject.FindGameObjectWithTag("TWE");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == truck)
        {
            truck.transform.parent = this.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == truck)
        {
            truck.transform.parent = null;
        }
    }
}
