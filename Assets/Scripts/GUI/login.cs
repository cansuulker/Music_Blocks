using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour
{

    public InputField usernameField;
    public InputField passwordField;



    // Use this for initializationpublic void CallLogin()
    public void CallLogin()
    {
        StartCoroutine(LoginTherapist());
    }

    IEnumerator LoginTherapist()
    {
        string targetURL = "http://localhost:8080/tmp/login_patient.php";
        Debug.Log("Logining " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(targetURL, form);
        yield return www;
        string trimmedwww = www.text.Trim();
        //string[] wwwText = www.text.Split(' ');
        if (trimmedwww[0] == '1')
        {
            Debug.Log("Logged In as ADMIN");
            DBManager.instance.username = usernameField.text;
            gameObject.SetActive(false); //Disable LoginMenu
            GameObject menu = transform.parent.Find("AdminMenu").gameObject;
            Debug.Log("Loading Admin Menu");
            menu.SetActive(true);
        }
        else if (trimmedwww[2] == '1')
        {
            Debug.Log("Logged In as PATIENT");
            DBManager.instance.username = usernameField.text;
            gameObject.SetActive(false); //Disable LoginMenu
            GameObject menu = transform.parent.Find("PatientMenu").gameObject;
            Debug.Log("Loading Patient Menu");
            menu.SetActive(true);
        }
        else if (trimmedwww[4] == '1')
        {
            Debug.Log("Logged In as THERAPIST");
            DBManager.instance.username = usernameField.text;
            gameObject.SetActive(false); //Disable LoginMenu
            GameObject menu = transform.parent.Find("TherapistMainMenu").gameObject;
            Debug.Log("Loading Threapist Menu");
            menu.SetActive(true);
        }
        else if (trimmedwww[6] == '1')
        {
            Debug.Log("Logged In as Normal");
            DBManager.instance.username = usernameField.text;
            gameObject.SetActive(false); //Disable LoginMenu
            GameObject menu = transform.parent.Find("PatientMenu").gameObject;
            Debug.Log("Loading Normal/Patient Menu");
            menu.SetActive(true);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }

    }

}