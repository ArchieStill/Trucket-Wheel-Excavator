using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUp : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public GameObject TruckObject;
    public Collider TruckCollider;
    public GameObject planeObject;
    public GameObject ghostObject;
    public GameObject ghostText;
    public GameObject gameWon;
    private bool hasCollided = false;

    public float speed = 3f;

    private void Awake()
    {
        hasCollided = false;
        ghostObject.SetActive(false);
        ghostText.SetActive(false);
        gameWon.SetActive(false);
        TruckObject = GameObject.FindGameObjectWithTag("TWE");
        TruckCollider = TruckObject.GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (hasCollided)
        {
            planeObject.transform.position = Vector3.MoveTowards(planeObject.transform.position, endPos.transform.position, step);
        }
        if (planeObject.transform.position == endPos.transform.position)
        {
            ghostObject.SetActive(true);
            ghostText.SetActive(true);
            gameWon.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == TruckCollider)
        {
            hasCollided = true;
        }
    }
}
