using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecurityQuestionChecker : MonoBehaviour
{
    public string attempt;
    public string password;
    public GameObject input;
    public GameObject userName;
    public GameObject incorrectPassword;
    public GameObject window;
    public AudioSource audio;
    public AudioClip incorrectEntryClip;
    public GameObject secondWindow;
    private bool allAnswered;
    private int countAnswer = 0;

    public void CheckAnswers()
    {
        Debug.Log(countAnswer);
        if(countAnswer == 3)
        {
            allAnswered = true;
        }
    }

    public void CheckPassword()
    {
        Debug.Log("Is this even working");
        attempt = GetComponent<InputField>().text;
        if (password.Equals(attempt))
        {
            input.SetActive(false);
            userName.SetActive(false);
            window.SetActive(true);
            countAnswer += 1;
            CheckAnswers();
            if(secondWindow != null && allAnswered)
            {
                secondWindow.SetActive(true);
                GameManager.gameManager.openedPC = true;
                GameManager.gameManager.Monologue(GameManager.gameManager.currentNode);
            }
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
        Debug.Log("should be making typing noise?");
        audio.pitch = Random.Range(1f, 1.2f);
        audio.Play();
    }
}
