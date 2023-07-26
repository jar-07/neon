using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public InputNeon WeaponInput;
    public Transform FirePoint;
    public Transform FirePoint2;
    public SpriteRenderer spriteRenderer_pistol;
    public GameObject BulletPrefab_W;
    public Rigidbody2D Bullet;
    public LineRenderer lineRenderer;
    public BulletEffects bulletEffects;
    public float LaserCounter;
    private float StoreCounter;
    public float speed;
    public bool isLaser;
    public int state;

    private void Awake()
    {
        WeaponInput = new InputNeon();
        WeaponInput.Player.Fire.started += Shoot;
        WeaponInput.Player.GetColor.started += GetGunColor;
        Bullet.GetComponent<Rigidbody2D>();
        StoreCounter = LaserCounter;
    }
    private void Update()
    {
        LaserCounter -= Time.deltaTime;
        if (isLaser)
        {
            if (LaserCounter <= 0)
            {
                lineRenderer.SetPosition(0, FirePoint.position);
                lineRenderer.SetPosition(1, FirePoint.position);
                isLaser = false;
            }
            
        }
    }


    private void OnEnable()
    {
        WeaponInput.Enable();
    }
    private void OnDisable()
    {
        WeaponInput.Disable();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (spriteRenderer_pistol.flipX == false)
        {
            Instantiate(BulletPrefab_W, FirePoint.position, FirePoint.rotation).GetComponent<Rigidbody2D>().velocity = (Vector2)(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized * speed * Time.deltaTime; ;
        }
        if (spriteRenderer_pistol.flipX == true)
        {
            Instantiate(BulletPrefab_W, FirePoint2.position, Quaternion.Inverse(FirePoint2.rotation)).GetComponent<Rigidbody2D>().velocity = (Vector2)(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized * speed * Time.deltaTime; ;

        }

    }
    private void GetGunColor(InputAction.CallbackContext context)
    {
        isLaser = true;
        if (spriteRenderer_pistol.flipX == false)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), 500, 7);
            if (hitInfo)
            {
                lineRenderer.SetPosition(0, FirePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                LaserCounter = StoreCounter;
                if (hitInfo.transform.name == "Magnenta")
                {
                    state = 1;
                }
                else if (hitInfo.transform.name == "Green")
                {
                    state = 2;
                }
                else if (hitInfo.transform.name == "Yellow")
                {
                    state = 3;
                }
                else if (hitInfo.transform.name == "Cyan")
                {
                    state = 4;
                }

            }
        }
        if (spriteRenderer_pistol.flipX == true)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint2.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), 500, 7);
            if (hitInfo)
            {
                lineRenderer.SetPosition(0, FirePoint2.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                LaserCounter = StoreCounter;
                if (hitInfo.transform.name == "Magnenta")
                {
                    state = 1;
                }
                else if (hitInfo.transform.name == "Green")
                {
                    state = 2;
                }
                else if (hitInfo.transform.name == "Yellow")
                {
                    state = 3;
                }
                else if (hitInfo.transform.name == "Cyan")
                {
                    state = 4;
                }


            }
        }

    }
}