using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life = 100;
    private GameObject enemyLife;

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

            // go to win screen
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
        }

    }

    public int LoseLife(int amount) {
        life -= amount;
        return life;
    }
}
