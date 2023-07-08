using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
