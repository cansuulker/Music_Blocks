using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControlPatients : MonoBehaviour
{
    private string patient_name;
    private string patient_surname;
    private string patient_id;
    [SerializeField]
    private GameObject buttonTemplate;
    void Start()
    {
        for (int i = 0; i < Therapist.patients.Length - 1; i += 2)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            patient_name = Therapist.patients[i].ToString();
            patient_surname = Therapist.patients[i + 1].ToString();

            button.GetComponent<ButtonListButtonPatients>().setText(patient_name + " " + patient_surname);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    public void setPatientInfo()
    {
        Patient.name = patient_name;
        Patient.surname = patient_surname;
    }
}
