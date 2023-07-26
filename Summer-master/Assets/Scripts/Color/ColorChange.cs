using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon weapon;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void FixedUpdate()
    {
        changeColor();
    }
    private void changeColor()
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
}
