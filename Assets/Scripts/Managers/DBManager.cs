/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static DBManager instance;
    public static string username;

    public bool LoggedIn { get { return username != ""; } }
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        instance = GetComponent<DBManager>();

    }
    public void LogOut()
    {
        username = null;
    }


}
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static DBManager instance;
    //public int id;
    public string username;
    //public int therapyID;
    //public string[] patients;
    //public string[] therapies;
    public bool LoggedIn { get { return username != ""; } }
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        instance = GetComponent<DBManager>();

    }
    public void LogOut()
    {
        username = null;
    }
    public void CallGetAllTherapies()
    {
        StartCoroutine(GetAllTherapies());
    }
    public void CallGetTherapistPatients()
    {
        StartCoroutine(GetTherapistPatients());
    }
    public void CallGetUserTherapy()
    {
        StartCoroutine(GetUserTherapy());
    }
    public void CallGetTherapyWithId()
    {
        StartCoroutine(GetTherapyWithId());
    }
    public void CallSubmitTherapy()
    {
        StartCoroutine(SubmitTherapy());
    }
    public void CallSubmitPatientTherapy()
    {
        StartCoroutine(SubmitPatientTherapy());
    }
    public void CallUpdateTherapy()
    {
        StartCoroutine(UpdateTherapy());
    }
    IEnumerator GetAllTherapies()
    {
        string targetURL = "http://localhost/tmp/get_all_therapies.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        WWW www = new WWW(targetURL, form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Therapy. Error # " + www.text);

        }
        else
        {
            //DBManager.username = usernameField.text; 
            //Debug.Log("yes");
            Debug.Log(www.text);
            Therapist.therapies = www.text.Split('\t');
            // for (int i = 0; i < Therapist.therapies.Length - 1; i++)
            // {
            //     Debug.Log(Therapist.therapies[i].ToString());
            // }

            //Therapist.therapies = www.text.Split('\t');

            //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator GetTherapistPatients()
    {
        string targetURL = "http://localhost/tmp/get_therapist_user.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("therapist_id", Therapist.id);
        WWW www = new WWW(targetURL, form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Therapy. Error # " + www.text);

        }
        else
        {
            //DBManager.username = usernameField.text; 
            Debug.Log(www.text);

            Therapist.patients = www.text.Split('\t');
            //Therapist.therapies = www.text.Split('\t');

            //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator GetUserTherapy()
    {
        string targetURL = "http://localhost/tmp/get_user_therapy.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("patient_id", Patient.id);
        WWW www = new WWW(targetURL, form);

        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Therapy. Error # " + www.text);
        }
        else
        {
            Debug.Log(www.text);
            //DBManager.username = usernameField.text; 
            //Patient.therapyId = int.Parse(www.text);
            string[] therapyParameters = www.text.Split('\t');
            GameSettings.setGameSettings(therapyParameters);
            GameSettings.debugLogSettings();
            // UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator GetTherapyWithId()
    {
        string targetURL = "http://localhost/tmp/get_therapy_with_id.php";
        Debug.Log("Getting therapies " + targetURL);

        WWWForm form = new WWWForm();
        form.AddField("therapy_id", Patient.therapyId);
        WWW www = new WWW(targetURL, form);

        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Therapy. Error # " + www.text);
        }
        else
        {
            Debug.Log(www.text);
            //DBManager.username = usernameField.text; 
            //Patient.therapyId = int.Parse(www.text);
            string[] therapyParameters = www.text.Split('\t');
            GameSettings.id = Patient.therapyId;
            GameSettings.setGameSettings(therapyParameters);
            GameSettings.debugLogSettings();
            // UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            //yield return new WaitForSeconds(3);
        }
    }
    IEnumerator SubmitTherapy()
    {
        string targetURL = "http://localhost/tmp/submit_therapy.php";
        Debug.Log("Logining patient " + targetURL);

        WWWForm form = new WWWForm();
        //addTherapyFields(form);
        //form.AddField("id", GameSettings.id);
        form.AddField("therapyName", GameSettings.therapyName);
        form.AddField("numberOfGames", GameSettings.numberOfGames);
        form.AddField("numberOfOperations", GameSettings.numberOfOperations);
        form.AddField("accuracy", GameSettings.accuracy.ToString());
        form.AddField("rotation", GameSettings.rotation.ToString());
        form.AddField("arithmetics", GameSettings.arithmetics.ToString());
        form.AddField("effects", GameSettings.effects.ToString());
        form.AddField("numberOfDigits", GameSettings.numberOfDigits);
        form.AddField("typeOfOperation", GameSettings.typeOfOperation);
        form.AddField("numberOfOperands", GameSettings.numberOfOperands);
       
        WWW www = new WWW(targetURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            Debug.Log("therapy added succesfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Therapist");

            //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
        }
    }
    IEnumerator SubmitPatientTherapy()
    {
        string targetURL = "http://localhost/tmp/submit_patient_therapy.php";
        Debug.Log("Logining patient " + targetURL);

        WWWForm form = new WWWForm();
        //addTherapyFields(form);
        //form.AddField("id", GameSettings.id);
        form.AddField("name", Patient.name);
        form.AddField("surname", Patient.surname);
        form.AddField("therapy_id", Patient.therapyId);

        WWW www = new WWW(targetURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            Debug.Log("patient-therapy added/updated succesfully");

            UnityEngine.SceneManagement.SceneManager.LoadScene("Therapist");
        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
        }
    }
    IEnumerator UpdateTherapy()
    {
        string targetURL = "http://localhost/tmp/update_therapy.php";
        Debug.Log("Logining patient " + targetURL);

        WWWForm form = new WWWForm();

        addTherapyFields(form);

        WWW www = new WWW(targetURL, form);
        yield return www;

        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            Debug.Log("therapy updated succesfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Therapist");

        }
        else
        {
            Debug.Log("User login failed. Error # " + www.text);
        }
    }
    public void addTherapyFields(WWWForm form)
    {
        form.AddField("id", GameSettings.id);
        form.AddField("therapyName", GameSettings.therapyName);
        form.AddField("numberOfGames", GameSettings.numberOfGames);
        form.AddField("numberOfOperations", GameSettings.numberOfOperations);
        form.AddField("accuracy", GameSettings.accuracy.ToString());
        form.AddField("rotation", GameSettings.rotation.ToString());
        form.AddField("arithmetics", GameSettings.arithmetics.ToString());
        form.AddField("effects", GameSettings.effects.ToString());
        form.AddField("numberOfDigits", GameSettings.numberOfDigits);
        form.AddField("typeOfOperation", GameSettings.typeOfOperation);
        form.AddField("numberOfOperands", GameSettings.numberOfOperands);

    }
}

