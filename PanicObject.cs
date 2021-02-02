using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicObject : MonoBehaviour
{

    [SerializeField]
    private float timeInPanic = 0;

    private GameObject[] enemies;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().IsInPanic(true);
            }

            StartCoroutine(noMorePanic());
        }
    }

    IEnumerator noMorePanic()
    {
        yield return new WaitForSeconds(timeInPanic);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().IsInPanic(false);
        }
    }
}
