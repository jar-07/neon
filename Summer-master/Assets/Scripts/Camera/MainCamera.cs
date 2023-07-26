using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    private void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector3(rb.position.x, rb.position.y, -10);
    }
}
