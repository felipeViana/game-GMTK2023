using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life = 100;
    GameObject enemyLife;
    // Start is called before the first frame update
    void Start()
    {
        enemyLife = GameObject.Find("EnemyLife");
        enemyLife.GetComponent<TMP_Text>().text = life.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        enemyLife.GetComponent<TMP_Text>().text = life.ToString();

        // die if life < 0
        if (life <= 0) {
            Destroy(gameObject);
        }

    }

    public int LoseLife(int amount) {
        life -= amount;
        return life;
    }
}
