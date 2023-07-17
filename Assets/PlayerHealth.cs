using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int life = 200;
    private GameObject lifeText;

    void Start()
    {
        lifeText = GameObject.Find("PlayerLife");
        lifeText.GetComponent<TMP_Text>().text = "PlayerLife: " + life.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        lifeText.GetComponent<TMP_Text>().text = "PlayerLife: " + life.ToString();


        // die if life < 0
        if (life <= 0) {
            Destroy(gameObject);

            // go to scene 1
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

    public int LoseLife(int amount) {
        life -= amount;
        Debug.Log("Player life: " + life);
        return life;
    }
}
