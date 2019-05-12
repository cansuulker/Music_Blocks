using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings {
    public static string therapyName = "Ornek Terapi";
    public static int id = 0;
    public static int numberOfGames = 10;
    public static int numberOfOperations = 10;
    public static float accuracy = 2;
    public static bool rotation = false;
    public static bool arithmetics = true;
    public static bool effects = true;
    public static int numberOfDigits = 1;
    public static int typeOfOperation = 0;
    public static int numberOfOperands = 2;


    public static void setGameSettings(string[] parameters)
    {
        GameSettings.id = int.Parse(parameters[1]);
        GameSettings.numberOfGames = int.Parse(parameters[2]);
        GameSettings.numberOfOperations = int.Parse(parameters[3]);
        GameSettings.accuracy = float.Parse(parameters[4]);
        GameSettings.rotation = parameters[5] != "True";
        GameSettings.arithmetics = parameters[6] != "False";
        GameSettings.effects = parameters[7] != "False"; //if not False, then True.
        GameSettings.numberOfDigits = int.Parse(parameters[8]);
        GameSettings.typeOfOperation = int.Parse(parameters[9]);
        GameSettings.numberOfOperands = int.Parse(parameters[10]);

    }
   
    public static string[] getGameSettings()
    {
        string[] settings = new string[10];

        settings[0] = GameSettings.id.ToString();
        settings[1] = GameSettings.numberOfGames.ToString();
        settings[2] = GameSettings.numberOfOperations.ToString();
        settings[3] = GameSettings.accuracy.ToString();
        settings[4] = GameSettings.rotation.ToString();
        settings[5] = GameSettings.arithmetics.ToString();
        settings[6] = GameSettings.effects.ToString();
        settings[7] = GameSettings.numberOfDigits.ToString();
        settings[8] = GameSettings.typeOfOperation.ToString();
        settings[9] = GameSettings.numberOfOperands.ToString();

        return settings;
    }
    public static void debugLogSettings()
    {

       

    }
}

