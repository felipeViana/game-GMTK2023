using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // moves like player
        var enemyCurrentPosition = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameObject.transform.position = new Vector3(-1, 0, 0) + enemyCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObject.transform.position = new Vector3(1, 0, 0) + enemyCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.transform.position = new Vector3(0, 0, 1) + enemyCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.position = new Vector3(0, 0, -1) + enemyCurrentPosition;
        }


        // adjust position to fit grid
        var enemyNewPosition = gameObject.transform.position;

        if (enemyNewPosition.x > 1) {
            gameObject.transform.position = new Vector3(1, 0, enemyNewPosition.z);
        } else if (enemyNewPosition.x < -1) {
            gameObject.transform.position = new Vector3(-1, 0, enemyNewPosition.z);
        } else if (enemyNewPosition.z > 3.5) {
            gameObject.transform.position = new Vector3(enemyNewPosition.x, 0, 3.5f);
        } else if (enemyNewPosition.z < 2.5) {
            gameObject.transform.position = new Vector3(enemyNewPosition.x, 0, 2.5f);
        }

        // force y to be 0.5
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);



    }
}
