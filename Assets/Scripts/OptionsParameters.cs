using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsParameters : MonoBehaviour
{
    public InputField therapyName;
    public Slider accuracy;
    public Toggle rotation;
    public Toggle effects;
    public Toggle arithmetics;
    public InputField numberOfGames;
    public InputField numberOfOperations;
    public Dropdown numberOfDigits;
    public Dropdown typeOfOperation;
    public InputField numberOfOperands;


    void Start()
    {
 
        therapyName.text = GameSettings.therapyName;
        accuracy.value = (float)GameSettings.accuracy;
        rotation.isOn = GameSettings.rotation;
        effects.isOn = GameSettings.effects;
        arithmetics.isOn = GameSettings.arithmetics;
        numberOfGames.text = GameSettings.numberOfGames.ToString();
        numberOfOperations.text = GameSettings.numberOfOperations.ToString();
        numberOfDigits.value = GameSettings.numberOfDigits;
        typeOfOperation.value = GameSettings.typeOfOperation;
        numberOfOperands.text = GameSettings.numberOfOperands.ToString();

    }
    public void passInputs()
    {
        GameSettings.therapyName = therapyName.text;
        GameSettings.numberOfGames = int.Parse(numberOfGames.text);
        GameSettings.numberOfOperations = int.Parse(numberOfOperations.text);
        GameSettings.accuracy = (float)accuracy.value;
        GameSettings.rotation = rotation.isOn;
        GameSettings.arithmetics = arithmetics.isOn;
        GameSettings.effects = effects.isOn;
        GameSettings.numberOfDigits = numberOfDigits.value;
        GameSettings.typeOfOperation = typeOfOperation.value;
        GameSettings.numberOfOperands = int.Parse(numberOfOperands.text);

       
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
}
