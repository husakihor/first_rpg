using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Speed at which the player will be moving
    public float speed = 2.0f;

    // Determine how high the player can jump
    public float jumpForce = 2.0f;

    // Describe state of player
    // if true then player is on ground
    // else player is jumping
    // in the future might be set to false if swimming
    public bool isGrounded;

    // Vectors for movements
    public Vector3 jump;
    public Vector3 move;
    
    // Rigidbody of the player,
    // used to check if the player is grounded.
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Function called when the rigidbody of the player enters in 
    // collision with a surface.
    void OnCollisionEnter() 
    {
        isGrounded = true;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the Horizontal input (minus or else wrong direction is taken)
        float hMove = -Input.GetAxisRaw("Horizontal");
        // Get the Vertical input
        float vMove = Input.GetAxisRaw("Vertical");

        // Compute new movement vector using the inputs
        move = new Vector3(vMove, 0.0f, hMove);

        // If a movement needs to be done then do the move.
        if (move != Vector3.zero)
        {
            transform.Translate(move * speed * Time.deltaTime, Space.World);
        }

        // Execute a jump if "Space" key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
