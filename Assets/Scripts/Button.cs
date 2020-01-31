using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : GenericObject
{
    public CodeLock codeLock;
    public int key;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Interact()
    {
        //print("boop");
        codeLock.PressKey(key);
    }
}