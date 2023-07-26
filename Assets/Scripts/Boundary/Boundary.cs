using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb_Player;
    public Rigidbody2D rb;
    public GameObject ColorObject;
    private Vector3 ColorBorn_RG;
    private Vector3 ColorBorn_B;

    private void Awake()
    {
        rb_Player.GetComponent<Rigidbody2D>();
        ColorObject.GetComponent<GameObject>();
    }

    private void FixedUpdate()
    {
        ColorBorn_RG = new Vector3(rb_Player.position.x - 21f, rb_Player.position.y + 12f, 0f);
        ColorBorn_B = new Vector3(rb_Player.position.x + 21f, rb_Player.position.y + 12f, 0f);
        if (transform.tag == "Left")
        {
            transform.position = new Vector3(rb_Player.position.x - 21f, transform.position.y, 0);
        }
        if (transform.tag == "Right")
        {
            transform.position = new Vector3(rb_Player.position.x + 21f, transform.position.y, 0);
        }
        rb.velocity = new Vector2(rb.velocity.x, -5f);
        ColorRoll();
    }

    private void ColorRoll()
    {
        if (ColorObject.transform.position.y < rb_Player.position.y - 12f)
        {
            if (transform.tag == "Left")
            {
                ColorObject.transform.position = ColorBorn_RG;
            }
            if (transform.tag == "Right")
            {
                ColorObject.transform.position = ColorBorn_B;
            }
        }
    }
}
