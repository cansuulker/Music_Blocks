using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
    public static bool fromPlayersScene = false;
    public static bool isNewTherapy = true;
    public static GUIManager instance;
    public GameObject gameOverMenu;
    void Awake()
    {
        instance = GetComponent<GUIManager>();
    }
    public void activateGameOverMenu()
    {
       
        gameOverMenu.SetActive(true);

    }

}
