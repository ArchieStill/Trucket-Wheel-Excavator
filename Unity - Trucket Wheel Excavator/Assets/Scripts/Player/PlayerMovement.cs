using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;
    public float animationSpeed = 1.5f;
    public Vector3 jumpVector;
    public float JumpForce = 2.0f;
    public bool isGrounded = true;
    public bool isPlayer = true;

    private Animator anim;
    private HashIDs hash;

    private void Update()
    {
        if (!isPlayer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                isPlayer = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.E))
            {
                isPlayer = false;
                Debug.Log("ISPLAYER FALSE");
            }
        }
    }

    void Awake()
    {
        if (isPlayer)
        {
            anim = GetComponent<Animator>();
            hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
            anim.SetLayerWeight(0, 0);

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

    void FixedUpdate()
    {
        if (isPlayer)
        {
            float move = Input.GetAxis("Move");
            bool sneak = Input.GetButton("Sneak");
            float turn = Input.GetAxis("Turn");
            bool jump = Input.GetButton("Jump");
            bool sprint = Input.GetButton("Sprint");
            Rotating(turn);
            MovementManagement(move, sprint, sneak, jump);
        }
    }

    void Rotating(float mouseXInput)
    {
        if (isPlayer)
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
    void MovementManagement(float move, bool sprinting, bool sneaking, bool jumping)
    {
        if (isPlayer)
        {
            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            anim.SetBool(hash.sneakingBool, sneaking);
            anim.SetBool(hash.jumpingBool, jumping);
            anim.SetBool(hash.sprintingBool, sprinting);
            if (Input.GetButton("Jump") && isGrounded)
            {
                ourBody.AddForce(jumpVector * JumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            if (move > 0)
            {
                anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
                if (Input.GetButton("Sprint"))
                {
                    anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
                }
            }
            else
            {
                anim.SetFloat(hash.speedFloat, 0);
            }
        }
    }
}
