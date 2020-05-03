using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : GenericObject
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

    public override void Interact()
    {
        Debug.Log("Pick Up the object: " + gameObject.name);
        PickUp(gameObject);

        string[] dialogue = gameObject.GetComponent<PickUpable>().dialogue;

        if (dialogue.Length > 0)
        {
            DialogueManager.diagMng.UpdateSpeech(dialogue);
            DialogueManager.diagMng.Say(dialogue[0]);
        }
    }

    void PickUp(GameObject obj)
    {
        InventoryManager.invManager.ObtainObject(obj);
        gameObject.SetActive(false);
    }
}
