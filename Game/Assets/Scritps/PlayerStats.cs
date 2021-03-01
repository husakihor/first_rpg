using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public int maxHealth = 100;
    public int stamina = 100;
    public int maxStamina = 100;
    public int strength;

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
    }

    void move()
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

    void hit(int damage)
    {
        if (damage < 1)
            return;
        health -= damage;
        if (health <= 0)
            Debug.Log("Dead");
    }
    // Update is called once per frame
    void Update()
    {
        move();
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            hit(10);
            Debug.Log(health);
        }
    }
}