using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPickup : PickUpable
{
    public GameObject[] otherPieces;
    public GameObject finishedBanana;

    private static int piecesCollected = 0;

    public override void Interact()
    {
        
        piecesCollected++;
        base.Interact();
        //print(piecesCollected);

        if (piecesCollected >= 3)
        {
            //print("beep");
            foreach (GameObject obj in otherPieces)
            {
                InventoryManager.invManager.RemoveObject(obj);
            }
            InventoryManager.invManager.ObtainObject(finishedBanana);
            DialogueManager.diagMng.UpdateSpeech(finishedBanana.GetComponent<PickUpable>().dialogue);
            DialogueManager.diagMng.Say(finishedBanana.GetComponent<PickUpable>().dialogue[0]);
            InventoryManager.invManager.RemoveObject(gameObject);
        }
    }
}
