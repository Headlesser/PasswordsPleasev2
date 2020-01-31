using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : GenericObject
{
    public CodeLock codeLock;
    public int key;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void KeyPress()
    {
        audioSource.Play();
    }
}