using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public double health;
    public double healthMax;

    public int expGiven;
    public int level;

    public GameObject[] droppableObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void onDeath()
    {
        int index = Random.Range(0, droppableObjects.Length);
        Instantiate(droppableObjects[index], transform.position, Quaternion.identity);
        Destroy(transform.root.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            health = -1;
        }
        if (health <= 0)
        {
            onDeath();
        }
    }
}
