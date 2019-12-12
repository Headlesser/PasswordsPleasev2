﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordChecker : MonoBehaviour
{
    public string attempt;
    public string password;
    public GameObject input;
    public GameObject userName;
    public GameObject incorrectPassword;
    public GameObject window;
    public AudioSource audio;
    public AudioClip incorrectEntryClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPassword()
    {
        attempt = GetComponent<InputField>().text;
        if (password.Equals(attempt))
        {
            input.SetActive(false);
            userName.SetActive(false);
            window.SetActive(true);
            GetComponent<AudioSource>().Play();
            incorrectPassword.SetActive(false);
        }
        else
        {
            GetComponent<InputField>().text = "";
            incorrectPassword.SetActive(true);
            audio.PlayOneShot(incorrectEntryClip);
        }
    }

    public void KeyboardClick()
    {
        audio.pitch = Random.Range(1f, 1.2f);
        audio.Play();
    }
}
