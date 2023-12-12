using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{

    public Transform spawnpoint;
    public GameObject bullet;
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ShootBullet();
        }
    }

    private void ShootBullet(){
        GameObject cB = Instantiate(bullet, spawnpoint.position, bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();
        Debug.Log(spawnpoint.forward);
        rig.AddForce(spawnpoint.forward * speed, ForceMode.Impulse);
    }
}
