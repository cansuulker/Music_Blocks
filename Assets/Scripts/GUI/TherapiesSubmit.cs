using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TherapiesSubmit : MonoBehaviour
{
    public GameObject submitButton;
    public GameObject editButton;
    public Text playerInfoText;

    // Use this for initialization
    void Start()
    {
        if (GUIManager.fromPlayersScene)
        {
            playerInfoText.text = "Secilen Oyuncu: " + Patient.name + " " + Patient.surname;
        }
        //submitButton = this.gameObject.GetComponent<GameObject>();
        //editButton = this.gameObject.GetComponent<GameObject>();
        //submitButton = Instantiate(submitButton) as GameObject;
        //editButton = Instantiate(editButton) as GameObject;

        submitButton.SetActive(false);
        editButton.SetActive(false);
    }
    public void setPatientInfo(string text)
    {
        Patient.therapyId = int.Parse(text);
    }
    public void onClickSubmit()
    {
        GUIManager.fromPlayersScene = false;
        GUIManager.isNewTherapy = true;

        DBManager.instance.CallSubmitPatientTherapy();
    }
    public void onClickEdit()
    {
        GUIManager.isNewTherapy = false;

        Patient.therapyId = ButtonListControlTherapies.selectedTherapyId;
        //GameSettings.id = ButtonListControlTherapies.selectedTherapyId;

        DBManager.instance.CallGetTherapyWithId();
        UnityEngine.SceneManagement.SceneManager.LoadScene("TherapistNewTherapy");
        //DBManager.instance.CallSubmitPatientTherapy();
    }
    public void onClickNewTherapy()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TherapistNewTherapy");
    }
    public void onClickExit()
    {
        GUIManager.fromPlayersScene = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("TherapistMainMenu");

    }
    public void enableButtons()
    {

        if (!GUIManager.fromPlayersScene)
        {
            editButton.SetActive(true);
        }
        else
        {
            submitButton.SetActive(true);
        }

    }
}
