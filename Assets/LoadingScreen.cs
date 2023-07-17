using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] float timeToLoadTotal = 5f;
    [SerializeField] float timeToLoadFirstText = 1.5f;
    [SerializeField] float timeToLoadSecondText = 3f;

    private float timeElapsed = 0f;
    private GameObject firstText;
    private GameObject secondText;


    void Start()
    {
        timeElapsed = 0f;
        firstText = GameObject.Find("FirstText");
        secondText = GameObject.Find("SecondText");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeToLoadFirstText) {
            firstText.GetComponent<TMPro.TMP_Text>().enabled = true;
        }

        if (timeElapsed > timeToLoadSecondText) {
            secondText.GetComponent<TMPro.TMP_Text>().enabled = true;
        }

        if (timeElapsed > timeToLoadTotal) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Combat");
        }
    }
}
