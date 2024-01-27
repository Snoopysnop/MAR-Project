using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUi : MonoBehaviour
{
    [SerializeField] private GameObject intText;
    [SerializeField] private float interactionDistance;
    private bool triggered = false;

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
            intText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Warehouse");
            }
        }
        else
        {
            intText.SetActive(false);
        }
    }
}
