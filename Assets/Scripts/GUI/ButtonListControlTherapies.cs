using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControlTherapies : MonoBehaviour
{
    //public static bool isSelected = false;
    public static int selectedTherapyId;
    private string therapy_id;
    [SerializeField]
    private GameObject buttonTemplate;
    [SerializeField]
    private Text therapyInfo;
    void Start()
    {
        for (int i = 0; i < Therapist.therapies.Length - 1; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            therapy_id = Therapist.therapies[i].ToString();

            button.GetComponent<ButtonListButtonTherapies>().setText(therapy_id);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    public void setSelectedTherapy(string id)
    {
        selectedTherapyId = int.Parse(id);
    }
    public void showTherapyInfo()
    {
        string[] settings = GameSettings.getGameSettings();
        therapyInfo.text = "Terapi No: " + settings[0] + "\n"
                            + "Bosluk Sayısı: " + settings[1] + "\n"
                            + "Islem Sayısı: " + settings[2] + "\n"
                            + "Kesinlik: " + settings[3] + "\n"
                            + "Rotasyon: " + settings[4] + "\n"
                            + "Aritmetik: " + settings[5] + "\n"
                            + "Efektler: " + settings[6] + "\n"
                            + "Basamak Sayısı: " + settings[7] + "\n" + "\n"

                            + "Islem Cesidi: " + settings[8] + "\n"
                            + "Islemci Sayısı: " + settings[9] + "\n"
           ;
    }
}
