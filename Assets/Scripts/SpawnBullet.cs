 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public float cadence;
    public float bulletForce;
    public Transform origen;
    private GameObject instance_bullet;

    void Awake()
    {
        //cadence = 0.25f;
        bulletForce = 25.0f;
        InvokeRepeating("FireBullets",0f,cadence);
        origen = this.transform;
    }

    private void FireBullets()
    {
        instance_bullet = Instantiate(bullet, origen.position,Quaternion.identity);
        instance_bullet.transform.right = origen.forward;
        instance_bullet.GetComponent<Rigidbody>().AddForce(origen.forward * bulletForce, ForceMode.Impulse );
    }

}
