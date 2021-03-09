using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public Transform camera;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float gravity = -18.62f;
    bool isGrounded;
    Vector3 velocity;

    public float jumpHeight = 1f;

    int isJumpingHash;
    int isGroundedHash;

    void Start() 
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        bool isAnimGrounded = animator.GetBool(isGroundedHash);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        bool runPressed = Input.GetKey("left shift");
        if (runPressed)
        {
            speed = 8f;
        }
        if (!runPressed)
        {
            speed = 5f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1 )
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
