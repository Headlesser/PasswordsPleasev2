using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarController : GenericObject
{

    public GameObject banama;
    public GameObject spotlight;
    public GameObject nameplate;

    public string[] dialogue;


    public override void Interact()
    {
        if (InventoryManager.invManager.CheckInventory(banama, true))
        {
            //print("Banana!");
            banama.SetActive(true);
            //spotlight.GetComponent<Light>().enabled = true;
            nameplate.SetActive(true);
            DialogueManager.diagMng.UpdateSpeech(dialogue);
            DialogueManager.diagMng.Say(dialogue[0]);
        }
    }
}
