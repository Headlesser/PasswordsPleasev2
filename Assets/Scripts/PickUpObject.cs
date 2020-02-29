using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Pickup"))
                {
                    if(GameManager.gameManager.currentNode.collectableObjects.Contains(hit.collider.gameObject))
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
                }
            }
        }
    }

    void PickUp(GameObject obj)
    {
        GameManager.gameManager.Inventory.Add(obj);

        InventoryManager.invManager.UpdateInventoryUI();
        gameObject.SetActive(false);
    }
}