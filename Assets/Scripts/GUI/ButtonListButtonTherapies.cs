using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButtonTherapies : MonoBehaviour
{

    [SerializeField]
    private Text myText;
    [SerializeField]
    private ButtonListControlTherapies buttonContol;
    [SerializeField]
    private TherapiesSubmit submitButtonContol;

    public void setText(string text)
    {
        myText.text = text;
    }
    public void onClick()
    {
        //ButtonListControlTherapies.isSelected = true;
        //buttonContol.setPatientInfo(myText.text);
        submitButtonContol.enableButtons();
        submitButtonContol.setPatientInfo(myText.text);
        buttonContol.setSelectedTherapy(myText.text);
        DBManager.instance.CallGetTherapyWithId();
        //Wait(3f);
        Debug.Log("before");
        StartCoroutine(Wait(0.5f));
        //buttonContol.showTherapyInfo();
        //Invoke("buttonContol.showTherapyInfo", 2);

    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //print("WaitAndPrint " + Time.time);
        Debug.Log("after");
        buttonContol.showTherapyInfo();
    }

}
