using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    private bool isDead;
    private float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
            
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Dammage(10);
            if(currentHealth <= 0)
            {
                isDead = true;
            }
        }
        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, currentHealth, lerpSpeed);
        }
    }

    void Dammage(float dammageValue)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= dammageValue;
        }
        
    }
}
