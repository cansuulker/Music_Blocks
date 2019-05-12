using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class register : MonoBehaviour
{
    public InputField nameField;
    public InputField surnameField;
    public InputField usernameField;
    public InputField passwordField;
    public Toggle therapistToggle;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Registerer());
    }


    IEnumerator Registerer()
    {
        string targetURL;
        if (therapistToggle.isOn)

            targetURL = "http://localhost:8080/tmp/register_therapist.php";
        else
            targetURL = "http://localhost:8080/tmp/register_patient.php";
        Debug.Log("Registering " + targetURL);


        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("surname", surnameField.text);
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(targetURL, form);
        yield return www;

        Debug.Log(www.text);
        if (www.text != "0")
        {
            Debug.Log("Registered User");
            gameObject.SetActive(false); //Disable RegisterPatientMenu
            GameObject menu = transform.parent.Find("MainMenu").gameObject;
            menu.SetActive(true);
        }
        else
        {
            Debug.Log("Register failed. Error #" + www.text);
        }


    }



    IEnumerator RegisterPatient()
    {
        string targetURL = "http://localhost:8080/unitygame/registerpatient.php";
        Debug.Log("Registering patient in " + targetURL);


        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.instance.username);
        form.AddField("patientName", usernameField.text);
        form.AddField("patientPass", passwordField.text);

        WWW www = new WWW(targetURL, form);
        yield return www;

        Debug.Log(www.text);
        if (www.text != "0")
        {
            Debug.Log("Registered Patient");
            gameObject.SetActive(false); //Disable RegisterPatientMenu
            GameObject menu = transform.parent.Find("TherapistMenu").gameObject;
            Debug.Log("Loading Threapist Menu");
            menu.SetActive(true);
        }
        else
        {
            Debug.Log("Patient register failed. Error #" + www.text);
        }


    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 2 &&
                                    surnameField.text.Length >= 2 &&
                                    usernameField.text.Length >= 4 &&
                                    passwordField.text.Length >= 4);
    }
}
