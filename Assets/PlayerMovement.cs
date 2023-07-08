using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var playerCurrentPosition = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector3(-1, 0, 0) + playerCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector3(1, 0, 0) + playerCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector3(0, 0, 1) + playerCurrentPosition;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector3(0, 0, -1) + playerCurrentPosition;
        }

        // adjust position to fit grid
        var playerNewPosition = gameObject.transform.position;

        if (playerNewPosition.x > 1) {
            gameObject.transform.position = new Vector3(1, 0, playerNewPosition.z);
        } else if (playerNewPosition.x < -1) {
            gameObject.transform.position = new Vector3(-1, 0, playerNewPosition.z);
        } else if (playerNewPosition.z > 1) {
            gameObject.transform.position = new Vector3(playerNewPosition.x, 0, 1);
        } else if (playerNewPosition.z < 0) {
            gameObject.transform.position = new Vector3(playerNewPosition.x, 0, 0);
        }

        // force y to be 0.5
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);


        // make camera follow player
        var cameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, cameraPosition.y, gameObject.transform.position.z);


    }
}
