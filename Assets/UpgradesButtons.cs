using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesButtons : MonoBehaviour
{
    [SerializeField] int extraHealth = 20;
    [SerializeField] float extraSpeed = 1f;
    [SerializeField] float extraShootCooldownReduction = 0.1f;
    [SerializeField] int extraShootAmount = 1;
    private void ToggleDoneButton(bool enabled)
    {
        GameObject doneButton = GameObject.Find("UpgradesDoneButton");
        doneButton.GetComponent<Button>().enabled = enabled;
        doneButton.GetComponent<Image>().enabled = enabled;
        doneButton.GetComponentInChildren<TMPro.TMP_Text>().enabled = enabled;
    }

    private void DisableAllButtons()
    {
        GameObject healthButton = GameObject.Find("Heart_Upgrade").GetComponentInChildren<Button>().gameObject;
        healthButton.GetComponent<Button>().enabled = false;

        GameObject speedButton = GameObject.Find("Speed_Upgrade").GetComponentInChildren<Button>().gameObject;
        speedButton.GetComponent<Button>().enabled = false;

        GameObject shootCooldownButton = GameObject.Find("ShootCD_Upgrade").GetComponentInChildren<Button>().gameObject;
        shootCooldownButton.GetComponent<Button>().enabled = false;

        GameObject shootAmountButton = GameObject.Find("ShootAmount_Upgrade").GetComponentInChildren<Button>().gameObject;
        shootAmountButton.GetComponent<Button>().enabled = false;
    }

    void Start()
    {
        ToggleDoneButton(false);
    }
    public void OnDoneButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GettingStronger");
    }

    public void OnHealthButtonClick()
    {
        // set outline
        GameObject healthButton = GameObject.Find("Heart_Upgrade").GetComponentInChildren<Button>().gameObject;
        healthButton.GetComponent<Outline>().enabled = true;

        DisableAllButtons();

        ToggleDoneButton(true);

        // add health
        PlayerPrefs.SetInt("PlayerLife", PlayerPrefs.GetInt("PlayerLife") + extraHealth);
    }

    public void OnSpeedButtonClick()
    {
        // set outline
        GameObject speedButton = GameObject.Find("Speed_Upgrade").GetComponentInChildren<Button>().gameObject;
        speedButton.GetComponent<Outline>().enabled = true;

        DisableAllButtons();
        ToggleDoneButton(true);
    }

    public void OnShootCooldownButtonClick()
    {
        // set outline
        GameObject shootCooldownButton = GameObject.Find("ShootCD_Upgrade").GetComponentInChildren<Button>().gameObject;
        shootCooldownButton.GetComponent<Outline>().enabled = true;

        DisableAllButtons();
        ToggleDoneButton(true);

        // add shoot cooldown reduction
        PlayerPrefs.SetFloat("shootCooldown", PlayerPrefs.GetFloat("shootCooldown") - extraShootCooldownReduction);
    }

    public void OnShootAmountButtonClick()
    {
        // set outline
        GameObject shootAmountButton = GameObject.Find("ShootAmount_Upgrade").GetComponentInChildren<Button>().gameObject;
        shootAmountButton.GetComponent<Outline>().enabled = true;

        DisableAllButtons();
        ToggleDoneButton(true);
    }

}
