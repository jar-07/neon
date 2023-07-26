using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 CollisonPlace;
    public Bullet bullet;
    public GameObject BulletEffect;
    public Animator animator;
    public bool Collison;
    private void FixedUpdate()
    {

        if (Collison == true)
        {
            Debug.Log(2);
            CollisonPlace = bullet.CollisonPosition;
            Instantiate(BulletEffect, CollisonPlace, Quaternion.identity);
            animator.SetTrigger("BulletEffect");
            Collison = false;
        }
    }
}
