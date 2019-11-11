using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    void OnMouseDown()
    {
        PickUp();
    }

    void PickUp()
    {
        if (GameManager.ins.currentNode.tag == "Pickup" && !GameManager.ins.Inventory.Contains(GameManager.ins.currentNode.GetComponent<Prop>())) //If the item has the tag pickup, aka, able to be picked up as an item
        {
            GameManager.ins.Inventory.Add(GameManager.ins.currentNode.GetComponent<Prop>()); //Add the NAME of that object to the list Inventory
            InventoryManager.invManager.UpdateInventoryUI();
            Destroy(gameObject); 
        }
    }

    void PutDown(string item)
    {
        //GameManager.ins.Inventory.Remove(item);
    }
}
