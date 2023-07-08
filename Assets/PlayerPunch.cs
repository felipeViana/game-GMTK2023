using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    bool punching = false;
    [SerializeField] private int punchDamage = 10;
    [SerializeField] private float punchTime = 0.5f;
    private float timePunching = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject leftArm = GameObject.Find("LeftArm/Arm");
        var defaultRotation = leftArm.transform.localRotation;

        if (!punching && Input.GetKeyDown(KeyCode.Space))
        {
            punching = true;
            Debug.Log("Punching");



            // make arm go straight
            leftArm.transform.localRotation = Quaternion.Euler(0, 0, 0);


            // check if it hits the enemy
            GameObject enemy = GameObject.Find("Enemy");

            if (enemy && this.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds))
            {
                Debug.Log("Hit the enemy");
            }



        }

        if (punching)
        {
            timePunching += Time.deltaTime;
            if (timePunching >= punchTime)
            {
                punching = false;
                timePunching = 0;

                // make arm go back
                leftArm.transform.localRotation = defaultRotation;
                Debug.Log("Punching done");
            }
        }


    }
}
