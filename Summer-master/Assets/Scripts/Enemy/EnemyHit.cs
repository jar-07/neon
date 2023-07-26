using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float BulletForce;
    public PlayerMove playerMove;
    public Transform BulletTransform;
    private Vector2 BulletFac;
    public Animator animator;
    public AIPath aIPath;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aIPath.GetComponent<AIPath>();
    }
    private void Update()
    {
        BulletFac = new Vector2(transform.position.x - BulletTransform.position.x, transform.position.y - BulletTransform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        aIPath.enabled = false;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("EnemyHit");
        rb.AddForce(BulletFac * BulletForce, ForceMode2D.Impulse);

    }

}
