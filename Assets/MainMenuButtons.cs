using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] int PlayerLife = 200;
    // speed
    // cooldown
    // shootAmount

    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerLife"))
        {
            Debug.Log("hiding continue button");
            // hide continue button
            GameObject.Find("Button_Continue").SetActive(false);
        }
    }
    public void OnStartButtonClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerLife", PlayerLife);


        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
    }

    public void OnContinueButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
    }

    public void OnSoundButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SoundMenu");
    }

    public void OnGraphicsButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GraphicsMenu");
    }

    public void OnAboutButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("About");
    }

    public void OnExitButtonClick()
    {
        Debug.Log("called exit");
        Application.Quit();
    }
}
