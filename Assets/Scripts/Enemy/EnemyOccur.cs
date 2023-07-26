using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyOccur : MonoBehaviour
{
    // Start is called before the first frame update
    public float Counter;
    public float StoreCounter;
    public int EnemyNumber;
    private int EnemyCounter = 0;
    public GameObject Enemy1;
    public GameObject NewEnemy;
    public Vector3 RandomPosotion;
    public Transform Player;
    private void Awake()
    {
        Enemy1.GetComponent<GameObject>();
        Counter = StoreCounter;
        Player.GetComponent<Transform>();
    }
    private void Update()
    {
        Counter -= Time.deltaTime;
        RandomPosotion = new Vector3(Player.position.x + Random.insideUnitCircle.x * 40, Player.position.y + Random.insideUnitCircle.y * 40, 0);
        BornEnemy();
    }

    private void BornEnemy()
    {
        if (Counter < 0)
        {
            if (EnemyCounter <= EnemyNumber)
            {
                NewEnemy = Instantiate(Enemy1, RandomPosotion, Quaternion.identity); EnemyCounter++;
                NewEnemy.transform.position = RandomPosotion;
                NewEnemy.GetComponent<Enemy1Data>().state = (int)((Random.value * 100) % 4 + 1);
                NewEnemy.GetComponent<AIPath>().enabled = true;
            }
            Counter = StoreCounter;
            EnemyCounter = 0;
        }
    }
}
