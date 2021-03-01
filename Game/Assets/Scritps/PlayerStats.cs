using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public double health = 100.0f;
    public double healthMax = 100.0f;
    public double stamina = 100.0f;
    public double staminaMax = 100.0f;
    public double strength;

    bool isRuning(Vector3 move)
    {
        return stamina > 0 && move != Vector3.zero;
    }

    void move()
    {
        PlayerController player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
        if (isRuning(player.move) && Input.GetKey(KeyCode.LeftShift))
        {
            player.speed = 5.0f;
            stamina -= 0.05;
            if (stamina <= 0)
            {
                stamina = 0;
                player.speed = 2.0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.speed = 2.0f;
        }
        else if (stamina < staminaMax)
        {
            stamina += 0.01;
            if (stamina > staminaMax)
            {
                stamina = staminaMax;
            }
        }
    }

    
    void hit(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Dead");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            hit(10);
            Debug.Log(health);
        }
    }
}