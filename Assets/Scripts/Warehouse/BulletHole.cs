using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletHole : MonoBehaviour
{
	public GameObject bulletHole;
	public float distance = 30f;
	Camera camera;
	
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
