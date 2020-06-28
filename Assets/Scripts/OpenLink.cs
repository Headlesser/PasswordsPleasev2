using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    public Color clickedColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(string link)
    {
        Application.OpenURL(link);
        GetComponent<Text>().color = clickedColor;
    }
}
