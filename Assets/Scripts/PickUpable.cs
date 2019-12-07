using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{
    public Location loc;
    public string name;
    public Sprite sprite;

    public bool readyToGrab;
    public void Start()
    {
        if (name == null)
            name = gameObject.name;
    }
}
