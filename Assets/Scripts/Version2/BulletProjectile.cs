using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform vfxHit;
    [SerializeField] private Transform vfxNoHit;

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            Instantiate(vfxHit, transform.position, Quaternion.identity);
            HealthBar hb = other.GetComponentInChildren<HealthBar>();
            if(hb != null)
            {
                hb.Dammage(20);
            }
            
        }
        else
        {
            Instantiate(vfxNoHit, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}