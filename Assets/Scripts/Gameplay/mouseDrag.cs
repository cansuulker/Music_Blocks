using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour {

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7);
            Camera temp = Camera.main;
            this.transform.position = temp.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,7);
        Camera temp = Camera.main;
        // Vector3 objPosition = temp.ScreenToWorldPoint(mousePosition);
        //transform.position = objPosition;
        this.transform.position = temp.ScreenToWorldPoint(mousePosition);

    }
}
