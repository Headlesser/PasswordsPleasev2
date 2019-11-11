using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    void OnMouseUp()
    {
        print("Pick up the stuff");
        if (GameManager.ins.currentNode == GetComponent<Prop>() && GameManager.ins.readyToGrab)
            PickUp();
        print("I am picking up this object " + gameObject);
    }

    void PickUp()
    {
        //GameManager.ins.currentNode.tag == "Pickup" && !GameManager.ins.Inventory.Contains(GameManager.ins.currentNode.GetComponent<Prop>()) &&
        if (true) //If the item has the tag pickup, aka, able to be picked up as an item
        {
            GameManager.ins.Inventory.Add(GameManager.ins.currentNode.GetComponent<Prop>()); //Add the NAME of that object to the list Inventory
            
            Destroy(gameObject); 
        }
    }

    void PutDown(string item)
    {
        //GameManager.ins.Inventory.Remove(item);
    }
}