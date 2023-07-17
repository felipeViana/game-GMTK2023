using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenuButtons : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

    }
}
