using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Data : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int state;
    public bool Enemy1Dead;
    public SpriteRenderer spriteRenderer;
    public GameObject EnemyItself;
    public Animator animator;
    public bool isDestroy;
    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer.GetComponent<SpriteRenderer>();
        EnemyItself.GetComponent<GameObject>();
        animator.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        ChangeColor();
        CheckDead();
    }
    private void ChangeColor()
    {

        if (state == 1)
        {
            spriteRenderer.color = Color.magenta;
        }
        else if (state == 2)
        {
            spriteRenderer.color = Color.green;
        }
        else if (state == 3)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (state == 4)
        {
            spriteRenderer.color = Color.cyan;
        }
    }
    private void CheckDead()
    {
        if (currentHealth <= 0)
        {
            Enemy1Dead = true;
            animator.SetBool("Enemy1Dead", Enemy1Dead);
        }
        if(isDestroy==true){
            Destroy(EnemyItself);
        }
    }
}
