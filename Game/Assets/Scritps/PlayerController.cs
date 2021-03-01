using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
