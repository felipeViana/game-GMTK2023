using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    enum Direction { Up, Right, Down, Left };

    [SerializeField] int movementsBeforeAttack = 5;
    [SerializeField] float movementTime = 0.2f;
    private float movementTimeLeft;
    [SerializeField] int punchDamage = 20;
    bool justMoved = false;
    int movementsDone = 0;
    bool justAttacked = false;
    bool punching = false;
    float timeAttacking = 1f;
    bool hit = false;

    bool animateToRight = true;

    // Start is called before the first frame update
    void Start()
    {
        movementTimeLeft = movementTime;

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

        if (movementsDone < movementsBeforeAttack && !justMoved && !punching)
        {
            hit = false;
            justMoved = true;
            justAttacked = false;
            movementsDone++;

            // moves randomly inside the grid
            Vector3 newPosition = new Vector3(0, 0, 0);
            do
            {
                int randomDirection = UnityEngine.Random.Range(0, 4);

                float newX = enemyCurrentPosition.x;
                float newZ = enemyCurrentPosition.z;

                // if (randomDirection == (int)Direction.Up)
                // {
                //     newZ++;
                // }
                if (randomDirection == (int)Direction.Right)
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

            if (animateToRight)
            {
                idle.transform.rotation = Quaternion.Euler(0, 0, 15);
            }
            else
            {
                idle.transform.rotation = Quaternion.Euler(0, 0, -15);
            }
            animateToRight = !animateToRight;
        }
        else if (justMoved)
        {
            movementTimeLeft -= Time.deltaTime;
            if (movementTimeLeft <= 0)
            {
                justMoved = false;
                movementTimeLeft = movementTime;
            }
        }
        else
        {
            movementsDone = 0;

            if (!justAttacked)
            {
                justAttacked = true;
                punching = true;

                var idle = GameObject.Find("Enemy/Idle");
                idle.GetComponent<MeshRenderer>().enabled = false;

                var punch = GameObject.Find("Enemy/Punch");
                punch.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        // time attacking
        if (punching)
        {
            if (!hit)
            {
                var player = GameObject.Find("Player");
                var playerPosition = player.transform.position;
                var enemyPosition = gameObject.transform.position;

                if (Math.Abs(playerPosition.x - enemyPosition.x) < 0.5 && enemyPosition.z - playerPosition.z < 1.5)
                {
                    hit = true;
                    var playerHealth = player.GetComponent<PlayerHealth>();
                    playerHealth.LoseLife(punchDamage);
                }
            }

            timeAttacking -= Time.deltaTime;
            if (timeAttacking <= 0)
            {
                punching = false;
                timeAttacking = 1f;

                // change to idle quad
                var idle = GameObject.Find("Enemy/Idle");
                idle.GetComponent<MeshRenderer>().enabled = true;

                var punch = GameObject.Find("Enemy/Punch");
                punch.GetComponent<MeshRenderer>().enabled = false;
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
