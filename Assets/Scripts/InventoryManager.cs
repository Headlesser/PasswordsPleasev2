using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager invManager;
    private List<GameObject> Inventory = new List<GameObject>();
    private int itemSelected = -1;

    // Start is called before the first frame update
    void Awake()
    {
        if (invManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            invManager = this;
        }
    }

    public void UpdateInventoryUI()
    {
        int i = 0;
        foreach (GameObject item in Inventory)
        {
            //print(gameObject.transform.GetChild(i));
            gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = item.GetComponent<PickUpable>().sprite;
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
            //gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().transition = 
            i++;
            if (i > transform.childCount)
                break;
        }
    }

    public bool CheckInventory(GameObject obj, bool consumed)
    {
        if (itemSelected == -1)
        {
            return false;
        }

        bool itemHeld = Inventory[itemSelected].Equals(obj);
        if (itemHeld)
        {
            if (consumed)
            {
                RemoveObject(Inventory[itemSelected]);
                UpdateInventoryUI();
            }
            itemSelected = -1;
            return true;
        }
        else
        {
            itemSelected = -1;
            return false;
        }
        
    }

    public void ObtainObject(GameObject obj)
    {
        Inventory.Add(obj);
        UpdateInventoryUI();
    }

    public void RemoveObject(GameObject obj)
    {
        Inventory.Remove(obj);
        UpdateInventoryUI();
    }

    public void InventorySelected(int slot)
    {
        itemSelected = slot;
    }
}
