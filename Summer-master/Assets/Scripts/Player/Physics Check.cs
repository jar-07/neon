using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    // Start is called before the first frame update
     public bool isGround;
    public LayerMask Ground;
    public float checkRadius;
    public Vector2 bottomOffset;
    public void Update()
    {
        Check();
    }
    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRadius, Ground);
    }
}
