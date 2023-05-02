using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;
    private float mouseX;
    private float mouseY;
    private float mouseZ;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseZ = Input.GetAxis("Mouse ScrollWheel");
        float angleBetween = Vector3.Angle(Vector3.up, transform.forward);

        if (Input.GetMouseButton (1))
        {
            offset = Quaternion.Euler(0, mouseX, 0) * offset;
        }
        if (((angleBetween > 90) && (mouseY < 0)) || ((angleBetween < 140) && (mouseY > 0)))
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 LocalRight = target.transform.worldToLocalMatrix.MultiplyPoint(transform.right);
                offset = Quaternion.AngleAxis(mouseY, LocalRight) * offset;
            }
        }
        if (mouseZ < 0)
        {
            offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
        }
        if (mouseZ > 0)
        {
            offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.95f));
        }
    }
}
