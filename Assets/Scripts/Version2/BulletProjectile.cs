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
        if(other.GetComponent<BulletTarget>() == null)
        {
            // Instantiate(vfxHit, transform.position, Quaternion.LookRotation(transform.forward));

            Instantiate(vfxHit, transform.position, Quaternion.identity);

        }
        else
        {
            // Instantiate(vfxHit, transform.position, Quaternion.LookRotation(transform.forward));

            Instantiate(vfxHit, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }


  

}
