using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject enemy;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //Invoke(nameof(Enemies), 1f);
            Instantiate(enemy);
        }
    }

    public void Enemies()
    {
        Instantiate(enemy, spawn.transform.position, transform.rotation);
    }
}
