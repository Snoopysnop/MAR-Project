using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTheDoor : MonoBehaviour
{

    public Animator doorAnimator;

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
            doorAnimator.SetBool("KeyIsCollected", inventory.GetItem("Key") == "true" && Input.GetKeyDown(KeyCode.E));
        }
    }
}
