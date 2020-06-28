using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    public Color clickedColor;


    public void Open(string link)
    {
        Application.OpenURL(link);
        GetComponent<Text>().color = clickedColor;
    }
}
