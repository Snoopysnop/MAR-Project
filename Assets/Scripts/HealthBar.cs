using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isPlayer;

    private Animator animator;
    private bool isDead;
    private float lerpSpeed = 0.05f;
    private bool hasToDie = false;
    private bool hasToDying = false;
    private bool cancel = false; 
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;

    }
    void Update()
    {
        if(healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
            
        }
        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, currentHealth, lerpSpeed);
        }
        if (hasToDying && !cancel)
        {
            cancel = true;
            animator.SetBool("WillDying", true);
            hasToDie = true;
            if (hasToDie)
            {
                animator.SetBool("isDead", true);
                if (transform.parent != null)
                {
                    transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Dammage(float dammageValue)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= dammageValue;
        }
        if (currentHealth <= 0)
        {
            isDead = true;
            if (isPlayer)
            {
                SceneManager.LoadScene("LostScene");
            }
            else
            {

                animator = GetComponentInParent<Animator>();
                EnemyController ec = GetComponentInParent<EnemyController>();
                ec.dead = true;
                hasToDying = true;

                
            }
        }
    }
}
