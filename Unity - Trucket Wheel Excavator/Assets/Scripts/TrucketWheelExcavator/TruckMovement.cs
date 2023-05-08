using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public bool isTruck = false;
    public float speed;
    public float sensitivity;
    public bool isMoving = false;

    Animator animator;
    private TruckHashIDs hash;
    private Rigidbody truckBody;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        truckBody = this.GetComponent<Rigidbody>();
    }

    /*private void Update()
    {
        if (anim == null)
        {
            Debug.Log("ANIM NULL");
        }
        if (hash == null)
        {
            Debug.Log("HASH NULL");
        }
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<TruckHashIDs>();
        anim.SetLayerWeight(0, 0);
        if (isTruck)
        {
            float move = Input.GetAxis("Move");
            bool spin = Input.GetButton("TruckOn");
            bool moving = Input.GetButton("Move");
            MovementManagement(move, spin, moving);
        }
    }*/

    void FixedUpdate()
    {
        if (isTruck)
        {
            float turn = Input.GetAxis("Turn");
            Rotating(turn);

            float forward = Input.GetAxisRaw("Move");

            Vector3 movement = new(forward, 0, 0f);
            movement *= speed;
            movement = transform.TransformDirection(movement);

            if (!Input.GetKeyDown(KeyCode.S))
            {
                truckBody.AddForce(movement, ForceMode.VelocityChange);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                truckBody.AddForce(-movement, ForceMode.VelocityChange);
            }
            isMoving = true;
            Debug.Log(isMoving);
        }
    }

    private void Update()
    {
        if (isTruck)
        {
            if (isMoving)
            {
                animator.SetBool("Driving", true);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                animator.SetBool("Spinning", true);
            }
        }
        else
        {
            animator.SetBool("Driving", false);
            animator.SetBool("Spinning", false);
        }
    }

    void Rotating(float xInput)
    {
        if (isTruck)
        {
            if (xInput != 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(0f, xInput * sensitivityX, 0f);
                truckBody.MoveRotation(truckBody.rotation * deltaRotation);
            }
        }
    }

    /*void MovementManagement(float move, bool spin, bool moving)
    {
        if (isTruck)
        {
            anim.SetBool(hash.spinBool, spin);
            if (move > 0)
            {
                anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
            }
            else
            {
                anim.SetFloat(hash.speedFloat, 0);
            }
        }
    }*/
}
