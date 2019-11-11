using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    public Location loc;
    public string name;
    public Sprite sprite;

    public void Start()
    {
        if (name == null)
            name = gameObject.name;
    }
}
