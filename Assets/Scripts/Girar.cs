using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girar : MonoBehaviour
{
    private float rotationSpeed;
    private Vector3 rotation;

    void Start()
    {
        rotationSpeed = Random.Range(-10.0f,10.0f);
        rotation = new Vector3(0.0f,rotationSpeed,0.0f);
    }

    void Update()
    {
        transform.Rotate(rotation*Time.deltaTime);
    }

}
