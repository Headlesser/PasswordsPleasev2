using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    public bool openDirection;
    public float openSpeed;
    int codeIndex;
    int codeLength;
    public bool finalCode;

    public string code = "";
    public string attemptedCode;

    public Transform openDoor;

    private AudioSource audioSource;
    [SerializeField] AudioSource safeAudio;
    [SerializeField] AudioClip deniedClip;
    [SerializeField] AudioClip acceptedClip;

    public string[] dialogue;

    private void Start()
    {
        openSpeed = 0.1f;
        codeLength = code.Length;
        audioSource = GetComponent<AudioSource>();
    }

    void CheckCode()
    {
        if (attemptedCode.Length < 4)
        {
            Debug.Log("Not Long Enough");
            safeAudio.clip = deniedClip;
            safeAudio.Play();
        }
        if (attemptedCode == code)
        {
            if (finalCode)
            {
                DialogueManager.diagMng.SetFinalSpeech(true);
            }
            StartCoroutine(OpenDoor());
            attemptedCode = "Accepted";
            safeAudio.clip = acceptedClip;
            safeAudio.Play();
            audioSource.Play();
            SetDisplay();
            DialogueManager.diagMng.UpdateSpeech(dialogue);
            DialogueManager.diagMng.Say(dialogue[0]);
        }
        else
        {
            Debug.Log("Wrong Code");
            attemptedCode = "Enter Code";
            SetDisplay();
            attemptedCode = "";
            safeAudio.clip = deniedClip;
            safeAudio.Play();
        }
    }

    IEnumerator OpenDoor()
    {
        float timeToStart = Time.time;
        Quaternion target = Quaternion.Euler(openDoor.transform.rotation.eulerAngles.x, openDoor.transform.rotation.eulerAngles.y, openDoor.transform.rotation.eulerAngles.z + 90f);
        if (!openDirection)
        {
            target = Quaternion.Euler(openDoor.transform.rotation.eulerAngles.x, openDoor.transform.rotation.eulerAngles.y, openDoor.transform.rotation.eulerAngles.z - 90f);
        }
        while (Vector3.Distance(openDoor.transform.rotation.eulerAngles, target.eulerAngles) > 0.5f)
        {
            openDoor.transform.rotation = Quaternion.Lerp(openDoor.transform.rotation, target, (Time.time - timeToStart) * openSpeed);
            yield return null;
        }

    }

    public void PressKey(int keyPressed)
    {
        if (keyPressed == -1)
        {
            ClearKey();
            return;
        }
        if (keyPressed == -2)
        {
            CheckCode();
            return;
        }
        if (attemptedCode.Length < 4)
        {
            attemptedCode = attemptedCode + keyPressed;
            SetDisplay();
        }
    }

    public void ClearKey()
    {
        attemptedCode = "Enter Code";
        SetDisplay();
        attemptedCode = "";
    }

    public void SetDisplay()
    {
        //displayText.text = attemptedCode;
    }
}