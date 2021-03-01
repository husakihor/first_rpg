using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public double health = 100.0f;
    public double healthMax = 100.0f;
    public double stamina = 100.0f;
    public double staminaMax = 100.0f;
    public double strength;

    // Checks if the player can run and if he is actually moving
    // Note : used to not waste stamina just by holding "LeftShift".
    bool isRuning(Vector3 move)
    {
        return stamina > 0 && move != Vector3.zero;
    }

    void move()
    {
        // Get the PlayerController Component from object
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

    
    void getHit(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Dead");
            //? Implement death mechanics here
        }
    }

    void FixedUpdate()
    {
        move();
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            getHit(10);
            Debug.Log(health);
        }
    }
}