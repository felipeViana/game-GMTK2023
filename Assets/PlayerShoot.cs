using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 15;
    [SerializeField] private float bulletLifeTime = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if mouse is pressed
        if (Input.GetMouseButtonDown(0)) {

            // shoot forward
            // find BulletPoint object
            GameObject bulletPoint = GameObject.Find("BulletPoint");

            // get the position of the BulletPoint
            Vector3 bulletPos = bulletPoint.transform.position;

            // go straigth on z axis
            Vector3 shootDirection = new Vector3(0, 0, 1);

            // create the bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);

            // set the bullet speed
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

            // destroy the bullet after some time
            Destroy(bullet, bulletLifeTime);




        }

    }
}
