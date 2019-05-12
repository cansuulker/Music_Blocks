using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardControl : MonoBehaviour
{
    public float speed;
    public float timer;
     void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(hor, 0, ver);
        this.transform.Translate(dir.normalized * Time.deltaTime *speed);

        if(Input.GetKey(KeyCode.Q)){
            blocks.spawned = true;

            Vector3 dir1 = new Vector3(0, -0.02f, 0);
            this.transform.Translate(dir1.normalized * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.E))
        {
            blocks.spawned = true;

            Vector3 dir2 = new Vector3(0, +0.02f, 0);
            this.transform.Translate(dir2.normalized * Time.deltaTime * speed);
        }
    }
}
