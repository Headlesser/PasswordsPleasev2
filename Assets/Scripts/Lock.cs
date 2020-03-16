using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        if (InventoryManager.invManager.CheckInventory(key))
            InventoryManager.invManager.RemoveObject(key);
        else
            Locked();
    }

    public void Locked()
    {
        //Play a message here
    }
}
