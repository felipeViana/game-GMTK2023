using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] int PlayerLife = 173;
    public void OnStartButtonClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PlayerLife", PlayerLife);


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
