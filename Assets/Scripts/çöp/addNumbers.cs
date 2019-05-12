using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class addNumbers : MonoBehaviour {
    public Canvas[] canvas;
    public Font myFont;

    void attachNumbers(){

        for (int i = 0; i < canvas.Length; i++){
            GameObject newText = new GameObject();
            newText.transform.SetParent(this.transform);
            Text text = newText.AddComponent<Text>();
            int rand = Random.Range(0, 10);
            string str = rand.ToString();
            text.text = str;
            text.font = myFont;
            text.fontSize = 15;

        }
    }

   void Start()
    {
        if(blocks.gameOver == true){
            attachNumbers();
        }

    }
}
