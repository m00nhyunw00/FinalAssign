using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class final_playerhealth : MonoBehaviourPunCallbacks
{
    float maxHealth = 1f;
    float currentHealth;
    public Slider healthSlider;
    public Slider healthSlider_Mine;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth / maxHealth;
        healthSlider_Mine.value = currentHealth / maxHealth;
    }

    [PunRPC]
    void Damage(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth / maxHealth;
        healthSlider_Mine.value = currentHealth / maxHealth;

        if (healthSlider.value <= 0)
        {
            Destroy(gameObject);
            print("Kill!!");
        }
    }
}