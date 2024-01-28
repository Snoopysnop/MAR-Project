using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeHostage : MonoBehaviour
{
    [SerializeField] GameObject hostage;
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
            if (inventory.GetItem("Knife") == "true" && Input.GetKeyDown(KeyCode.E))
            {
                inventory.addItem(hostage.name, "true");
                Destroy(hostage);
            }
        }
    }
}
