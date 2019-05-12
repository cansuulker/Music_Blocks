using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partScript : MonoBehaviour {

    public GameObject obj;
     void Start()
    {
        obj.GetComponent<ParticleSystem>();
    }

}
