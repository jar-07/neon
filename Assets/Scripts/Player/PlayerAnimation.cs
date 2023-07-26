using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb.GetComponent<Rigidbody2D>();
        physicsCheck.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetAnimation();
    }
    private void SetAnimation()
    {
        animator.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
        animator.SetBool("isGround", physicsCheck.isGround);
    }

    public void SetTrigger()
    {
        animator.SetTrigger("isHurt");
    }
}
