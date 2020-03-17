using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lock : MonoBehaviour
{
    public GameObject key;

    public void Checkkey()
    {
        if (InventoryManager.invManager.CheckInventory(key))
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
