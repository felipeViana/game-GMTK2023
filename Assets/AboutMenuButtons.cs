using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMenuButtons : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }
}
