using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if(transform.position.z < -25.0f || transform.position.x > 21.0f || transform.position.z > 30.0f )
            Destroy(this.gameObject);
    }

}
