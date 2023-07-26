using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform groundCheck;
    public bool isGround;
    public LayerMask Ground;
    public float checkRadius;
    public Vector2 bottomOffset;
    [SerializeField] ContactFilter2D filter;
    Collider2D[] results = new Collider2D[1];
    public void Update()
    {
        Check();
    }
    public void Check()
    {
        if (Physics2D.OverlapBox(groundCheck.position, groundCheck.localScale, 0, filter, results) > 0)
        {
            isGround = true;
        }
        else
        {
            isGround= false;
        }
        {

        }
    }
}
