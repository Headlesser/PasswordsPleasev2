﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletPassword : MonoBehaviour
{
    public string password;
    public string attempt;
    public Text[] inputField;
    public GameObject lockScreen;
    private bool coroutinActive = false;
    public GameObject screenshot;
    public GameObject enableKey;

    AudioSource audio;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] Animation shakeAnimation;

    public string[] dialogue;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void AddInput(string input)
    {
        if (GameManager.gameManager.currentNode == gameObject.GetComponent<Node>() && !coroutinActive)
        {
            attempt += input;
            inputField[attempt.Length - 1].text = input;
            audio.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            audio.Play();
            if (attempt.Length >= password.Length)
                if (CheckInput())
                    Unlock();
                else
                {
                    StartCoroutine(ShakeScreen(1f));
                    //ClearInput();
                    shakeAnimation.Play();
                }
        }
    }

    public bool CheckInput()
    {
        return (attempt.Equals(password));
    }

    public void ClearInput()
    {
        attempt = "";
        foreach (Text t in inputField)
        {
            t.text = "";
        }
    }

    public void Unlock()
    {
        lockScreen.SetActive(false);
        screenshot.SetActive(true);
        GameManager.gameManager.openedTablet = true;
        //GameManager.gameManager.Monologue(GameManager.gameManager.currentNode);
        enableKey.SetActive(true);
        //Debug.Log(enableKey.activeSelf);
        DialogueManager.diagMng.UpdateSpeech(dialogue);
        DialogueManager.diagMng.Say(dialogue[0]);

    }

    private IEnumerator ShakeScreen(float waitTime)
    {
        coroutinActive = true;
        //TODO: shaking is hard, Ill do it later
        yield return new WaitForSeconds(waitTime);
        ClearInput();
        coroutinActive = false;
    }
}
