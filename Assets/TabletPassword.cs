using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInput(string input)
    {
        if (GameManager.gameManager.currentNode == gameObject.GetComponent<Node>() && !coroutinActive)
        {
            attempt += input;
            inputField[attempt.Length - 1].text = input;
            if (attempt.Length >= password.Length)
                if (CheckInput())
                    Unlock();
                else
                {
                    StartCoroutine(ShakeScreen(1f));
                    //ClearInput();
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
