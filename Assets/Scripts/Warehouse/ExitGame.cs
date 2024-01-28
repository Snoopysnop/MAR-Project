using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private bool triggered = false;
    private PlayerInventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = true;
            inventory = other.gameObject.GetComponent<PlayerInventory>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered = false;
        }
    }
    void Update()
    {

        if (triggered)
        {
            if(inventory.GetItem("Sophie") == "true" &&
               inventory.GetItem("Chris") == "true" &&
               inventory.GetItem("Megan") == "true" &&
               Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("WinScene");
            }
             
        }
    }
}
