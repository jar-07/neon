using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;
    public GameObject ob_Bullet;
    public GameObject BulletEffect_W;
    public GameObject BulletEffect_M;
    public GameObject BulletEffect_G;
    public GameObject BulletEffect_Y;
    public GameObject BulletEffect_C;
    public Vector3 CollisonPosition;
    public SpriteRenderer spriteRenderer;
    public Weapon weapon;
    public Animator animator;
    public Enemy1Data enemy1Data;
    public float Damage;
    private void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
        spriteRenderer.GetComponent<SpriteRenderer>();
        BulletEffect_W.GetComponent<GameObject>();
        BulletEffect_M.GetComponent<GameObject>();
        BulletEffect_G.GetComponent<GameObject>();
        BulletEffect_Y.GetComponent<GameObject>();
        BulletEffect_C.GetComponent<GameObject>();
        enemy1Data.GetComponent<Enemy1Data>();
    }
    private void FixedUpdate()
    {
        ChangeColor();
        ChangeEffect();
    }
    private void OnBecameInvisible()
    {
        Destroy(ob_Bullet);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(ob_Bullet);
        ChangeEffect();
        animator.SetBool("isEffect", true);
        if (other.tag == "Enemy")
        {
            if (weapon.state == other.GetComponent<Enemy1Data>().state)
            {
                other.GetComponent<Enemy1Data>().currentHealth -= Damage;
            }
        }
    }

    private void ChangeColor()
    {
        if (weapon.state == 1)
        {
            spriteRenderer.color = Color.magenta;
        }
        if (weapon.state == 2)
        {
            spriteRenderer.color = Color.green;
        }
        if (weapon.state == 3)
        {
            spriteRenderer.color = Color.yellow;
        }
        if (weapon.state == 4)
        {
            spriteRenderer.color = Color.cyan;
        }
    }

    private void ChangeEffect()
    {
        if (weapon.state == 0)
        {
            Instantiate(BulletEffect_W, transform.position, Quaternion.identity);
        }
        if (weapon.state == 1)
        {
            Instantiate(BulletEffect_M, transform.position, Quaternion.identity);
        }
        if (weapon.state == 2)
        {
            Instantiate(BulletEffect_G, transform.position, Quaternion.identity);
        }
        if (weapon.state == 3)
        {
            Instantiate(BulletEffect_Y, transform.position, Quaternion.identity);
        }
        if (weapon.state == 4)
        {
            Instantiate(BulletEffect_C, transform.position, Quaternion.identity);
        }
    }
}
