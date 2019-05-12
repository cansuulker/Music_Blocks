using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour {
  
    // Use this for initialization
    void Start()     {
        // Set starting position and speed
        SetPositionAndSpeed();     }

    public void SetPositionAndSpeed()     {
        var x = -3f;         var y = 4f;
        var z = 2f;         transform.position = new Vector3(x, y, z);
    }
}
