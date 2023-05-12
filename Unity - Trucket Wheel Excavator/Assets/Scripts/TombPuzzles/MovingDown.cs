using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDown : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public ButtonPress buttonPress;

    public float speed = 3f;

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (buttonPress.isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
        }
    }
}
