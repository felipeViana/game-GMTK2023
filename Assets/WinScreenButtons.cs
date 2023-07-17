using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenButtons : MonoBehaviour
{
    public void OnPlayAgainButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }

    public void OnQuitButtonClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
