using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float enemySpeed;
    public Rigidbody thisRigidbody;
    private Vector3 direccion;

    void Start()
    {
        enemySpeed = 10.0f;
        //thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);

        if(transform.position.x < -25.0f || transform.position.x > 21.0f || transform.position.z < -25.0f )
            Destroy(transform.root.gameObject);
    }



}
