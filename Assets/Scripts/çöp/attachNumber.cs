//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class attachNumber : MonoBehaviour
//{

//    public Font myFont;
//    public GameObject dutyPanel;
//    public List<GameObject> object_list = blocks.object_list;
//    public int sum = blocks.sum;
//    public List<int> numbers = new List<int>();
//    // Use this for initialization
//    void Start()
//    {
       
//    }

//   public void attach()
//    {
//        TextMesh panelTxt = dutyPanel.GetComponentInChildren<TextMesh>();
//        sum = Random.Range(2, 18);
//        panelTxt.text = sum.ToString();
//        int randIndex = Random.Range(0, object_list.Count);
//        int randIndex2 = Random.Range(0, object_list.Count);
//        while (randIndex == randIndex2)
//        {
//            randIndex = Random.Range(0, object_list.Count);
//        }

//        Canvas canvas = object_list[randIndex].GetComponentInChildren<Canvas>();
//        Text txt = canvas.GetComponentInChildren<Text>();
//        Canvas canvas2 = object_list[randIndex2].GetComponentInChildren<Canvas>();
//        Text txt2 = canvas2.GetComponentInChildren<Text>();
//        bool nonzero = false;
//        int rand = 0;
//        int otherNumber = 0;
//        while (!nonzero)
//        {
//            rand = Random.Range(1, 10);
//            otherNumber = sum - rand;
//            if (otherNumber != 0)
//                nonzero = true;
//        }
//        string str = rand.ToString();
//        string str2 = otherNumber.ToString();

//        txt.text = str;
//        txt2.text = str2;

//        txt.font = myFont;
//        txt.fontSize = 55;
//        txt2.font = myFont;
//        txt2.fontSize = 55;

//        numbers.Add(int.Parse(str));
//        numbers.Add(int.Parse(str2));

//        for (int i = 0; i < object_list.Count; i++)
//        {
//            if (i != randIndex && i != randIndex2)
//            {
//                Canvas can = object_list[i].GetComponentInChildren<Canvas>();
//                Text text = can.GetComponentInChildren<Text>();
//                int randomN = Random.Range(1, 10);
//                string s1 = randomN.ToString();
//                text.text = s1;
//                text.font = myFont;
//                text.fontSize = 55;

//                numbers.Add(int.Parse(s1));
//            }
//        }

//    }
//}
