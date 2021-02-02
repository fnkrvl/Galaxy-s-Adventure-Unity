using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life = 100;

    public GameObject particles;

    private float maxLife = 100;

    Vector3 initialPosition;

    GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = player.transform.position;
    }


    public void Update()
    {
        if (life > maxLife)
        {
            life = maxLife;
        }

        if (life <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageImpact)
    {
        life -= damageImpact;

        if (life <= 0)
        {
            player.transform.position = initialPosition;
        }
    }
}
