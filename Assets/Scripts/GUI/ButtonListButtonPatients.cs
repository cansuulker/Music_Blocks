using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButtonPatients : MonoBehaviour
{
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControlPatients buttonContol;
    public void setText(string text)
    {
        myText.text = text;
    }
    public void onClick()
    {

        buttonContol.setPatientInfo();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Therapies");
    }
}
