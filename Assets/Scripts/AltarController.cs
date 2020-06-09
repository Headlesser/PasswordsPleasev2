using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarController : GenericObject
{

    public GameObject banama;
    public GameObject spotlight;
    public GameObject nameplate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (InventoryManager.invManager.CheckInventory(banama, true))
        {
            //print("Banana!");
            banama.SetActive(true);
            //spotlight.GetComponent<Light>().enabled = true;
            nameplate.SetActive(true);
        }
    }
}
