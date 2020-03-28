using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetLock : Lock
{

    public GameObject door;
    public Transform doorDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Locked()
    {
        string[] speech = { "", "" };
        DialogueManager.diagMng.UpdateSpeech(speech);
        DialogueManager.diagMng.Say(speech[0]);
        //Display message here
    }

    public override void Unlock()
    {
        door.transform.position = doorDestination.position;
        GameManager.gameManager.openedFlowerCabinet = true;
        GameManager.gameManager.Monologue(GameManager.gameManager.currentNode);
    }
}
