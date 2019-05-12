using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffect : MonoBehaviour {
    public ParticleSystem particle;
	// Use this for initialization
	void Start () {

	}
   
	// Update is called once per frame
	void Update () {
        particle.Play();

    }
}
