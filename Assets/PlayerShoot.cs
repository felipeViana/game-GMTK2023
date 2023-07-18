using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 15;
    [SerializeField] private float bulletLifeTime = 2f;
    private float shootCooldown;
    private float timeElapsed = 0f;
    private bool shooting = false;
    private GameObject cooldownText;


    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = PlayerPrefs.GetFloat("shootCooldown");

        cooldownText = GameObject.Find("ShootCoolDown");
        cooldownText.GetComponent<TMPro.TMP_Text>().text = "Shoot Cooldown: " + String.Format("{0:N2}", shootCooldown - timeElapsed) + "s" + " / " + String.Format("{0:N2}", shootCooldown) + "s";
    }

    // Update is called once per frame
    void Update()
    {
        cooldownText.GetComponent<TMPro.TMP_Text>().text = "Shoot Cooldown: " + String.Format("{0:N2}", shootCooldown - timeElapsed) + "s" + " / " + String.Format("{0:N2}", shootCooldown) + "s";

        // check if mouse is pressed
        if (Input.GetMouseButtonDown(0) && !shooting) {
            shooting = true;

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

        if (shooting) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > shootCooldown) {
                shooting = false;
                timeElapsed = 0f;
            }
        }

    }
}
