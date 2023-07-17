using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GettingStronger : MonoBehaviour
{
    [SerializeField] float timeToLoadTotal = 3f;
    [SerializeField] float timeToLoadSecondPanel = 1.5f;

    private float timeElapsed = 0f;
    private GameObject firstPanel;
    private GameObject secondPanel;


    void Start()
    {
        timeElapsed = 0f;
        firstPanel = GameObject.Find("Panel");
        secondPanel = GameObject.Find("SecondPanel");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeToLoadSecondPanel) {
            // disable image component of first panel
            firstPanel.GetComponent<Image>().enabled = false;
            secondPanel.GetComponent<Image>().enabled = true;
        }

        if (timeElapsed > timeToLoadTotal) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
        }
    }
}
