using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDealDamage : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 10;


    bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if it hits the enemy
        GameObject enemy = GameObject.Find("Enemy");

        if (!hit && enemy && this.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds)) {


            // deal damage to the enemy
            enemy.GetComponent<EnemyLife>().LoseLife(bulletDamage);

            hit = true;
        }

    }
}
