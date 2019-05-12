using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGameParameters : MonoBehaviour {

    public string therapyName;
    public int numberOfGames;
    public int numberOfOperations;
    public float accuracy;
    public bool rotation;
    public bool arithmetics;
    public bool effects;
    public int numberOfDigits;
    public int typeOfOperation;
    public int numberOfOperands;


     Dropdown m_Dropdown;
     string m_Message;
     int m_DropdownValue;

    public string[] options1 = { "Tek Basamak", "Çift Basamak" };
    public string[] options2 = { "Toplama", "Çıkarma", "Çarpma", "Hepsi" };

    public void adjustAccuracy(float acc)
    {
        accuracy = acc;
    }

    public void getInput(string str)
    {
        int num = int.Parse(str);
        if (num <= 21)
            numberOfGames = num;
        else
            Debug.Log("En fazla 21 oyun oynanabilir");

    }

    public void getToggleRotation(bool val)
    {
        rotation = val;
    }

    public void getToggleArit(bool val)
    {
        arithmetics = val;
    }

    public void getToggleEffects(bool val)
    {
        effects = val;
    }
    public void getInputOperations(string str)
    {
        int num = int.Parse(str);
        numberOfOperations = num;
    }
    public void getNumDigits(Dropdown d)
    {
        m_DropdownValue = d.value;

        m_Message = d.options[m_DropdownValue].text;

        if (m_Message == options1[0])
        {
            numberOfDigits = 1;
        }
        else
            numberOfDigits = 2;
         
    }
    public void getOperationType(Dropdown d)
    {
        m_DropdownValue = d.value;

        m_Message = d.options[m_DropdownValue].text;

        if (m_Message == options2[0])
            typeOfOperation = 0;
        if (m_Message == options2[1])
            typeOfOperation = 1;
        if (m_Message == options2[2])
            typeOfOperation = 2;
        if (m_Message == options2[3])
            typeOfOperation = 3;

    }

    public void getNumOperands(string str)
    {
        int num = int.Parse(str);
        if (num > 3)
            Debug.Log("Üçten fazla operand seçilemez");
        numberOfOperands = num;
    }

    public void passInputs()
    {
        GameSettings.therapyName = therapyName;
        GameSettings.numberOfGames = numberOfGames;
        GameSettings.numberOfOperations = numberOfOperations;
        GameSettings.accuracy = accuracy;
        GameSettings.rotation = rotation;
        GameSettings.arithmetics = arithmetics;
        GameSettings.effects = effects;
        GameSettings.numberOfDigits = numberOfDigits;
        GameSettings.typeOfOperation = typeOfOperation;
        GameSettings.numberOfOperands = numberOfOperands;
    }
    public void submitParameters()
    {
        if (GUIManager.isNewTherapy)
        {
            DBManager.instance.CallSubmitTherapy();
        }
        else
        {
            DBManager.instance.CallUpdateTherapy();
        }
    }
    public void sendParameters()
    {
        DontDestroyOnLoad(this);
    }

}
