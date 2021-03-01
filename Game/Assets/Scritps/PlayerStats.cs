using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject.Find("Player(Clone)").GetComponent<PlayerController>().speed = 5.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GameObject.Find("Player(Clone)").GetComponent<PlayerController>().speed = 2.0f;
        }
    }
}