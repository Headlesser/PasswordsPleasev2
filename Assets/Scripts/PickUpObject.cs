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
                    if (hit.collider.gameObject.GetComponent<PickUpable>().readyToGrab)
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
        InventoryManager.invManager.ObtainObject(obj);
        gameObject.SetActive(false);
    }
}