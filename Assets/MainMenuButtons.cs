using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Combat");
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
