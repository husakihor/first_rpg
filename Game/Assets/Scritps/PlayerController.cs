using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter() 
    {
        isGrounded = true;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hMove = -Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(vMove, 0.0f, hMove);
        if (move != Vector3.zero)
        {
            transform.Translate(move * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
