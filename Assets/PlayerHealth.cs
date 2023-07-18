using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int life;
    private GameObject lifeText;

    void Start()
    {
        life = PlayerPrefs.GetInt("PlayerLife");

        lifeText = GameObject.Find("PlayerLife");
        lifeText.GetComponent<TMP_Text>().text = "Health: " + life.ToString() + " / " + PlayerPrefs.GetInt("PlayerLife");

    }

    // Update is called once per frame
    void Update()
    {
        lifeText.GetComponent<TMP_Text>().text = "Health: " + life.ToString() + " / " + PlayerPrefs.GetInt("PlayerLife");


        // die if life < 0
        if (life <= 0) {
            Destroy(gameObject);

            // go to Upgrades scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
        }

    }

    public int LoseLife(int amount) {
        life -= amount;
        Debug.Log("Player life: " + life);
        return life;
    }
}
