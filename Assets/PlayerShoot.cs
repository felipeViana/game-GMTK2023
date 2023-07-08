using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if mouse is pressed
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("shoot");

            // shoot a raycast
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject.tag == "Enemy") {
                    Debug.Log("hit enemy");
                    hit.collider.gameObject.GetComponent<EnemyLife>().LoseLife(1);
                }
            }
        }

    }
}
