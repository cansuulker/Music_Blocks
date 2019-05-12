using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUserInfo : MonoBehaviour {
    public string username;
    public string password;
    public string name;
    public string surname;

	// Use this for initialization
    public void getUsername(string u)
    {
        username = u;
    }
    public void getPassword(string p)
    {
        password = p;
    }
    public void getName(string n)
    {
        name = n;
    }
    public void getSurname(string s)
    {
        surname = s;
    }
    public void sendParameters()
    {
        DontDestroyOnLoad(this);
    }
}
