using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchItem : MonoBehaviour
{

    [SerializeField] private GameObject item;
    private bool triggered = false;
    public PlayerInventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
    void Update()
    {
        if (triggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.addItem(item.name, "true");
                Destroy(item);
            }
        }
    }
}
