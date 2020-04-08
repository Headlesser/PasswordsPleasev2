using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lock : GenericObject
{
    public GameObject key;
    public Node locationNode;

    public override void Interact()
    {
        Checkkey();
    }

    public void Checkkey()
    {
        print(GameManager.gameManager.currentNode.ToString());
        if (InventoryManager.invManager.CheckInventory(key, true) && GameManager.gameManager.currentNode == locationNode)
        {
            InventoryManager.invManager.RemoveObject(key);
            Unlock();
        }
        else
            Locked();
    }

    public abstract void Locked(); //Used for interaction with object whithout key
    public abstract void Unlock(); //Used for interaction with object whith key
}
