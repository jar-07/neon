using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
[Header("Basic Data")]
    public int Damage;

    public float attackFreq;

    public float attackRange;
    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<PlayerData>()?.TakeDamage(this);
    }
}
