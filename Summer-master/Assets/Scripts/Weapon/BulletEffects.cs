using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDestroy;
    public GameObject Effect;
    public SpriteRenderer spriteRenderer;
    public int state;
    private void FixedUpdate()
    {
        if (isDestroy == true)
        {
            Destroy(Effect);
        }
    }
}
