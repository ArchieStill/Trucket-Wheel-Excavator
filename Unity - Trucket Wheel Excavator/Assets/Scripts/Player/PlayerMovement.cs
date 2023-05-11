using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public Vector3 jumpVector;
    public float jumpForce = 2.5f;
    public bool isGrounded = true;
    public GameObject Excavator;
    public GameObject smokeObject;

    private bool isPlayer = true;
    private float elapsedTime = 0;
    private bool noBackMov = true;
    private float desiredDuration = 0.5f;
    private Animator anim;
    private HashIDs hash;
    private Rigidbody ourBody;
    RaycastHit hit;

    void Awake()
    {
        if (isPlayer)
        {
            anim = GetComponent<Animator>();
            hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
            anim.SetLayerWeight(0, 0);
            ourBody = this.GetComponent<Rigidbody>();
            smokeObject.SetActive(false);

            jumpVector = new Vector3(0, 2.0f, 0);
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Update()
    {
        if (isPlayer)
        {
            float move = Input.GetAxis("Move");
            bool sneak = Input.GetButton("Sneak");
            bool jump = Input.GetButtonDown("Jump");
            bool sprint = Input.GetButton("Sprint");
            MovementManagement(move, sprint, sneak, jump);
            this.gameObject.transform.parent = null;

            elapsedTime += Time.deltaTime;
            bool shout = Input.GetKeyDown(KeyCode.P);
            anim.SetBool("Shouting", true);
            AudioManagement(shout);
        }
        else if (!isPlayer)
        {
            this.gameObject.transform.parent = Excavator.transform;
        }
    }

    void FixedUpdate()
    {
        if (isPlayer)
        {
            float turn = Input.GetAxis("Turn");
            Rotating(turn);
        }
    }

    public void Enable()
    {
        isPlayer = true;
    }
    public void Disable()
    {
        isPlayer = false;
        anim.SetFloat(hash.speedFloat, 0);
    }
    public bool GetIsPlayer()
    {
        return isPlayer;
    }

    void Rotating(float xInput)
    {
        if (isPlayer)
        {
            if (xInput != 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(0f, xInput * sensitivityX, 0f);
                ourBody.MoveRotation(ourBody.rotation * deltaRotation);
            }
        }
    }
    void MovementManagement(float move, bool sprinting, bool sneaking, bool jumping)
    {
        if (isPlayer)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            /// Debug.DrawRay(transform.position, Vector3.down, Color.red, 1);
            Physics.Raycast(ray, out hit);
            if (hit.distance < 0.25f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            anim.SetBool(hash.sneakingBool, sneaking);
            anim.SetBool(hash.jumpingBool, jumping);
            anim.SetBool(hash.sprintingBool, sprinting);
            if (jumping && isGrounded)
            {
                ourBody.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            if (move > 0)
            {
                anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
                anim.SetBool("Backwards", false);
                noBackMov = true;
                if (Input.GetButtonDown("Sprint"))
                {
                    anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
                    smokeObject.transform.position = ourBody.position;
                    smokeObject.transform.parent = transform;
                    smokeObject.SetActive(true);
                }
            }
            else if (move < 0)
            {
                if (noBackMov)
                {
                    elapsedTime = 0;
                    noBackMov = false;
                }
                float percentageComplete = elapsedTime / desiredDuration;

                anim.SetFloat(hash.speedFloat, -animationSpeed, speedDampTime, Time.deltaTime);
                anim.SetBool("Backwards", true);

                ourBody = this.GetComponent<Rigidbody>();
                float movement = Mathf.Lerp(0f, -0.025f, percentageComplete);
                Vector3 moveBack = new(0f, 0f, movement / 4);
                moveBack = ourBody.transform.TransformDirection(moveBack);
                ourBody.transform.position += moveBack;
                smokeObject.transform.parent = null;
            }
            else
            {
                anim.SetFloat(hash.speedFloat, 0);
                anim.SetBool(hash.backwardsBool, false);
                noBackMov = true;
                smokeObject.transform.parent = null;
            }
        }
    }

    void AudioManagement(bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().pitch = 0.5f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }
}
