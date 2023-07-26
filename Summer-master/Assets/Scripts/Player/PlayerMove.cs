using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic Data")]
    public float speed;
    public float JumpForce;
    public float hitForce;
    public bool isHit = false;
    public Rigidbody2D rb;
    public InputNeon input;
    public Vector2 InputDirec;
    public PhysicsCheck physicsCheck;
    public SpriteRenderer spriteRenderer_Weapon;
    public float DiffBtwMouseandPlayer;
    public bool FacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new InputNeon();
        input.Player.Jump.started += Jump;
    }


    private void FixedUpdate()
    {
        InputDirec = input.Player.Move.ReadValue<Vector2>();
        if (!isHit)
        {
            Move();
            Flip();
            CheckDiff();
        }
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Move()
    {   
        rb.velocity = new Vector2(InputDirec.x * speed * Time.deltaTime, rb.velocity.y);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }
    private void Flip()
    {
        if (DiffBtwMouseandPlayer < 0 && FacingRight == true)
        {
            transform.Rotate(0, 180, 0);
            FacingRight = false;
            spriteRenderer_Weapon.flipX = true;
        }
        if (DiffBtwMouseandPlayer > 0 && FacingRight == false)
        {
            transform.Rotate(0, 180, 0);
            FacingRight = true;
            spriteRenderer_Weapon.flipX = false;
        }
    }
    private void CheckDiff()
    {
        DiffBtwMouseandPlayer = Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x; ;
    }
    public void OnHitPlayer(Transform attacker)
    {
        rb.velocity = Vector2.zero;
        Vector2 hitDir = new Vector2(transform.position.x - attacker.position.x, 0).normalized;
        rb.AddForce(hitDir * hitForce, ForceMode2D.Impulse);
        isHit = true;
    }

}