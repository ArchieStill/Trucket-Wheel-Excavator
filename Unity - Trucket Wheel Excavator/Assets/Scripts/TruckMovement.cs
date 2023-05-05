using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public bool isTruck = false;

    void Awake()
    {
        if (isTruck)
        {
            /*anim = GetComponent<Animator>();
            hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
            anim.SetLayerWeight(0, 0);*/

        }
    }

    private void FixedUpdate()
    {
        if (isTruck)
        {
            float move = Input.GetAxis("Move");
            float turn = Input.GetAxis("Turn");
            Rotating(turn);
            MovementManagement(move);
        }
    }

    void Rotating(float mouseXInput)
    {
        if (isTruck)
        {
            // access the player's rigidbody
            Rigidbody ourBody = this.GetComponent<Rigidbody>();

            // check whether we have rotation data to apply
            if (mouseXInput != 0)
            {
                // use mouse input to create a Euler angle which provides rotation in the Y axis
                // this value is then turned into a Quarternion
                Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);
                // this value is applied to turn the body via the rigidbody
                ourBody.MoveRotation(ourBody.rotation * deltaRotation);
            }
        }
    }

    void MovementManagement(float move)
    {
        if (isTruck)
        {
            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            // float playerHeight = gameObject.transform.localScale.y;

            /*if (move > 0)
            {
                anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat(hash.speedFloat, 0);
            }*/
        }
    }
}
