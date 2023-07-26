using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider healthBar;
    public Slider damageeffect;
    public float damageeffectspeed = 0.0005f;
    private bool isEffecting = false;
    private void Update()
    {
        if (isEffecting)
        {
            if(healthBar.value < damageeffect.value)
            {
                damageeffect.value -= damageeffectspeed;
            }
            else
            {
                healthBar.value = damageeffect.value;
                isEffecting = false;
            }
        }
    }
    public void setHealth(float health)
    {
        //设置血量
        if(health < 0){
            PlayerData.currentHealth = 0;
        }
        //小于0设置成0
        else if (health > PlayerData.maxHealth){
            PlayerData.currentHealth = PlayerData.maxHealth;
        }
        //大于maxHealth设置成maxHealth
        else{
            PlayerData.currentHealth = health;
        }
        healthBar.value = PlayerData.currentHealth/PlayerData.maxHealth;
        damageeffect.value = healthBar.value;
            
    }
    public void changeHealth(float change)
    {
        if (change > 0) 
        { 
            if(PlayerData.currentHealth+change>PlayerData.maxHealth){
                PlayerData.currentHealth = PlayerData.maxHealth;
            }
            else{
                PlayerData.currentHealth += change;
            }
            healthBar.value = PlayerData.currentHealth / PlayerData.maxHealth;
            damageeffect.value = healthBar.value;
        }
        else if (change < 0)
        {
            if(PlayerData.currentHealth + change < 0){
                PlayerData.currentHealth = 0;
            }
            else{
                PlayerData.currentHealth += change;
            }
            healthBar.value = PlayerData.currentHealth / PlayerData.maxHealth;
            isEffecting = true;
        }
    }
}
