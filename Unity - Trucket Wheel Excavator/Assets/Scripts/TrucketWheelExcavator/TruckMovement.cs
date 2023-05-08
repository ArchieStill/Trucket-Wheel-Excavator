using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public bool isTruck = false;

    private Animator anim;
    private TruckHashIDs hash;
    private Rigidbody ourBody;

    void Awake()
    {
        if (isTruck)
        {
            /*anim = GetComponent<Animator>();
            hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<TruckHashIDs>();
            anim.SetLayerWeight(0, 0);
            ourBody = this.GetComponent<Rigidbody>();*/
        }
    }

    private void Update()
    {
        /*if (anim == null)
        {
            Debug.Log("ANIM NULL");
        }
        if (hash == null)
        {
            Debug.Log("HASH NULL");
        }*/
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<TruckHashIDs>();
        anim.SetLayerWeight(0, 0);
        ourBody = this.GetComponent<Rigidbody>();
        if (isTruck)
        {
            float move = Input.GetAxis("Move");
            bool spin = Input.GetButton("TruckOn");
            bool moving = Input.GetButton("Move");
            MovementManagement(move, spin, moving);
        }
    }

    void FixedUpdate()
    {
        if (isTruck)
        {
            float turn = Input.GetAxis("Turn");
            Rotating(turn);
        }
    }

    void Rotating(float xInput)
    {
        if (isTruck)
        {
            if (xInput != 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(0f, xInput * sensitivityX, 0f);
                ourBody.MoveRotation(ourBody.rotation * deltaRotation);
            }
        }
    }

    void MovementManagement(float move, bool spin, bool moving)
    {
        if (isTruck)
        {
            anim.SetBool(hash.spinBool, spin);
            if (move > 0)
            {
                // anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
                anim.SetBool(hash.driveBool, moving);
                Debug.Log(hash.driveBool);
            }
            else
            {
                // anim.SetFloat(hash.speedFloat, 0);
            }
        }
    }
}
