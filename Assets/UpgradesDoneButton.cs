using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesDoneButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GettingStronger");

    }
}
