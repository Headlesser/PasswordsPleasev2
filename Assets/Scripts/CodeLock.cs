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

    public string code = "";
    public string attemptedCode;

    public Transform openDoor;

    private void Start()
    {
        openSpeed = 0.1f;
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if (attemptedCode.Length < 4)
        {
            Debug.Log("Not Long Enough");
        }
        if (attemptedCode == code)
        {
            StartCoroutine(OpenDoor());
            attemptedCode = "Accepted";
            SetDisplay();
        }
        else
        {
            Debug.Log("Wrong Code");
            attemptedCode = "Enter Code";
            SetDisplay();
            attemptedCode = "";
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