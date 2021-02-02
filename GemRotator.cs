using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotator : MonoBehaviour
{
    [SerializeField]
    private float speedRotation;

    void Update()
    {
        transform.Rotate(0f, 0f, speedRotation * Time.deltaTime);
    }
}
