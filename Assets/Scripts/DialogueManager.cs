using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager diagMng;

    public GameObject speechPanel;
    public TMP_Text speechText;
    //public Text speechText;
    public GameObject continueOnText;
    public string targetSpeech = "";

    public bool isSpeaking { get { return speaking != null; } }
    public bool talking;
    [HideInInspector] public bool isWaitingForUserInput = false;
    
    Coroutine speaking = null;
    private bool finalSpeech;

    public string[] speech;
    int i = 0;

    public void Awake()
    {
        talking = true;
        if (DialogueManager.diagMng == null)
        {
            diagMng = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (talking && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !GameManager.gameManager.paused)
        {
            if (i < speech.Length)
            {
                Say(speech[i]);
            }
            else
            {
                Close();
                if (finalSpeech)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }

    public void UpdateSpeech(string[] newSpeech)
    {
        i = 0;
        speech = newSpeech;
    }

    ///<summary>
    ///Say something and show it on the speech box.
    /// </summary>
    public void Say(string speech)
    {
        
        speechPanel.SetActive(true);
        
        //stop the speaking coroutine before moving onto the next line
        StopSpeaking();
        
        speaking = StartCoroutine(Speaking(speech, false));
        talking = true;
        i++;
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
        targetSpeech = speech;
        continueOnText.SetActive(false);

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
        continueOnText.SetActive(true);

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
        talking = false;
    }

    public void SetFinalSpeech(bool b)
    {
        finalSpeech = b;
    }
}
