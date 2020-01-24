﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject speechPanel;
    public Text speechText;
    public GameObject continueText;
    public string targetSpeech = "";

    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector] public bool isWaitingForUserInput = false;
    
    Coroutine speaking = null;

    public string[] speech;
    int i = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(i < speech.Length)
            {
                Say(speech[i]);
            }
            else
            {
                Close();
            }

            i++;
        }
    }

    ///<summary>
    ///Say something and show it on the speech box.
    /// </summary>
    public void Say(string speech)
    {
        //stop the speaking coroutine before moving onto the next line
        StopSpeaking();

        speaking = StartCoroutine(Speaking(speech, false));
    }

    public void StopSpeaking()
    {
        //check if speaker is speaking
        if(isSpeaking)
        {
            StopCoroutine(speaking);
        }

        speaking = null;
    }

    IEnumerator Speaking(string speech, bool additive)
    {
        speechPanel.SetActive(true);
        targetSpeech = speech;
        continueText.SetActive(false);

        if (!additive)
        {
            speechText.text = "";
        }
        else
        {
            targetSpeech = speechText.text + targetSpeech;
        }

        isWaitingForUserInput = false;

        //add characters to the screen until it matches the target speech
        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }
       
        //make the continue indication text reappear
        continueText.SetActive(true);

        //text finished
        isWaitingForUserInput = true;

        while(isWaitingForUserInput)
        {
            yield return new WaitForEndOfFrame();
        }

        StopSpeaking();
    }

     public void Close()
    {
        StopSpeaking();
        speechPanel.SetActive(false);
    }
}