using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDetection : MonoBehaviour
{
    public string messageText = "Appuyez sur E pour interagir";
    public float detectionDistance = 5f;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green, 20f);
        Debug.Log(transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, detectionDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("button"))
            {
                Debug.Log(messageText);
                Debug.Log("ALLER LA");

            }
            else
            {
                Debug.Log("boubou");

            }
        }
    }
}