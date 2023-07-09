using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    enum Direction { Up, Right, Down, Left };

    [SerializeField] int movementsBeforeAttack = 5;
    [SerializeField] float movementTime = 1f;
    bool justMoved = false;
    int movementsDone = 0;
    bool justAttacked = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool isPositionValid(Vector3 position)
    {
        if (position.x > 1.1 || position.x < -1.1 || position.z > 3.3 || position.z < 2.1)
        {
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        // moves like player
        var enemyCurrentPosition = gameObject.transform.position;

        if (movementsDone < movementsBeforeAttack && !justMoved)
        {
            justMoved = true;
            justAttacked = false;
            movementsDone++;

            // moves randomly inside the grid
            Vector3 newPosition = new Vector3(0, 0, 0);
            do
            {
                int randomDirection = Random.Range(0, 4);

                float newX = enemyCurrentPosition.x;
                float newZ = enemyCurrentPosition.z;

                if (randomDirection == (int)Direction.Up)
                {
                    newZ++;
                }
                else if (randomDirection == (int)Direction.Right)
                {
                    newX++;
                }
                else if (randomDirection == (int)Direction.Down)
                {
                    newZ--;
                }
                else if (randomDirection == (int)Direction.Left)
                {
                    newX--;
                }

                newPosition = new Vector3(newX, 0.5f, newZ);

            } while(!isPositionValid(newPosition));

            gameObject.transform.position = newPosition;

            // rotate randomly
            var idle = GameObject.Find("Enemy/Idle");
            // set idle rotation
            idle.transform.rotation = Quaternion.Euler(-0.02175789f, 0, Random.Range(-15, 15));


        }
        else if (justMoved)
        {
            movementTime -= Time.deltaTime;
            if (movementTime <= 0)
            {
                justMoved = false;
                movementTime = 1f;
            }
        }
        else
        {
            movementsDone = 0;

            if (!justAttacked)
            {
                justAttacked = true;
                // attack
                Debug.Log("enemy attack");

                // change to punch quad

                var idle = GameObject.Find("Enemy/Idle");


                // disable mesh renderer of idle
                // idle.GetComponent<MeshRenderer>().enabled = false;

                // var punch = GameObject.Find("Enemy/Punch");
                // punch.GetComponent<MeshRenderer>().enabled = true;

                // gameObject.transform.GetChild(0).gameObject.SetActive(false);
                // gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }



        // // debug movement
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     gameObject.transform.position = new Vector3(-1, 0, 0) + enemyCurrentPosition;
        // }
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     gameObject.transform.position = new Vector3(1, 0, 0) + enemyCurrentPosition;
        // }
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     gameObject.transform.position = new Vector3(0, 0, 1) + enemyCurrentPosition;
        // }
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     gameObject.transform.position = new Vector3(0, 0, -1) + enemyCurrentPosition;
        // }


        // adjust position to fit grid
        var enemyNewPosition = gameObject.transform.position;

        if (enemyNewPosition.x > 1) {
            gameObject.transform.position = new Vector3(1, 0, enemyNewPosition.z);
        } else if (enemyNewPosition.x < -1) {
            gameObject.transform.position = new Vector3(-1, 0, enemyNewPosition.z);
        } else if (enemyNewPosition.z > 4) {
            gameObject.transform.position = new Vector3(enemyNewPosition.x, 0, 3f);
        } else if (enemyNewPosition.z < 2) {
            gameObject.transform.position = new Vector3(enemyNewPosition.x, 0, 2f);
        }

        // force y to be 0.5
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);



    }
}
