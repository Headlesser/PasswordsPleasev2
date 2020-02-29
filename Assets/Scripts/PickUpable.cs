using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{ 
    public string name;
    public Sprite sprite;
    public string[] dialogue;

    public bool readyToGrab;
    public void Start()
    {
        if (name == null)
            name = gameObject.name;
    }
}
