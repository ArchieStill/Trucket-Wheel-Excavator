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
    public bool isSpinning = false;

    Animator animator;
    public GameObject wheelCollider;
    public GameObject wheelParticles;

    private TruckHashIDs hash;
    private Rigidbody truckBody;

    void Start()
    {
        animator = GetComponent<Animator>();
        this.gameObject.transform.parent = wheelCollider.transform;
        wheelParticles.SetActive(false);
        truckBody = this.GetComponent<Rigidbody>();
    }

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
        }
    }

    private void Update()
    {
        if (isTruck)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

            if (isMoving)
            {
                animator.SetBool("Driving", true);
            }

            if (Input.GetButton("Spin"))
            {
                animator.SetBool("Spinning", true);
                wheelCollider.SetActive(true);
                wheelParticles.transform.parent = transform;
                wheelParticles.SetActive(true);
                isSpinning = true;
            }
            if (Input.GetButton("StopSpin"))
            {
                animator.SetBool("Spinning", false);
                wheelCollider.SetActive(false);
                wheelParticles.SetActive(false);
                isSpinning = false;
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            animator.SetBool("Driving", false);
            animator.SetBool("Spinning", false);
            isSpinning = false;
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
}
