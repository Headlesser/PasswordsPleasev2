using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    void OnMouseUp()
    {
        // print("Pick up the stuff");
        // if (GameManager.ins.currentNode == GetComponent<Prop>() && GameManager.ins.readyToGrab)
        //     PickUp();
        // print("I am picking up this object " + gameObject);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //print("The current node location: " + GameManager.ins.currentNode);
            //UpdatePickUpColliders();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Pickup"))
                {
                    if(GameManager.ins.currentNode == GetComponent<PickUpable>().loc && GetComponent<PickUpable>().readyToGrab == true)
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
                    else
                    {
                        this.GetComponent<PickUpable>().readyToGrab = true;
                    }
                }
            }
        }
    }

    private void UpdatePickUpColliders()
    {//For every item in the list of all possible pickup items
        foreach (GameObject item in GameManager.ins.AllPickups)
        {//If the current node is that item's location, set it active to be picked up. Otherwise, deactivate it.
            if(GameManager.ins.currentNode == item.GetComponent<PickUpable>().loc)
            {
                item.GetComponent<PickUpable>().readyToGrab = true;
            }
            else if(GameManager.ins.currentNode != item.GetComponent<PickUpable>().loc)
            {
                item.GetComponent<PickUpable>().readyToGrab = false;
            }
        }
    }

    void PickUp(GameObject obj)
    {
        GameManager.ins.Inventory.Add(obj);

        InventoryManager.invManager.UpdateInventoryUI();
        gameObject.SetActive(false);

        //Destroy(gameObject);
        //Debug.Log(GameManager.ins.Inventory[0]);
        // if (true) //If the item has the tag pickup, aka, able to be picked up as an item
        // {
        //     GameManager.ins.Inventory.Add(GameManager.ins.currentNode.GetComponent<Prop>()); //Add the NAME of that object to the list Inventory

        //     Destroy(gameObject);
        // }
    }

    void PutDown(string item)
    {
        //GameManager.ins.Inventory.Remove(item);
    }
}