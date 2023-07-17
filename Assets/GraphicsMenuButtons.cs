using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsMenuButtons : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }

    public void OnToggleFullScreenButtonClick()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
