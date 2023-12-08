using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer;
    public float height;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        Debug.Log("camera controller");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log("camera controller");

        transform.position = player.transform.position - player.transform.forward * distanceFromPlayer;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
    }
}

