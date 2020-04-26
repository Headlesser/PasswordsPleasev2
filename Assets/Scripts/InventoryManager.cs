using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager invManager;
    private List<GameObject> Inventory = new List<GameObject>();
    private int itemSelected = -1;
    public Color unselectedColor;
    public Color selectedColor;
    public GameObject[] inventorySlots;

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
            //print(item.name);
            inventorySlots[i].GetComponent<Image>().sprite = item.GetComponent<PickUpable>().sprite;
            //inventorySlots[i].gameObject.SetActive(true);
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
            gameObject.transform.GetChild(itemSelected).GetComponent<Image>().color = unselectedColor;
            itemSelected = -1;
            return true;
        }
        else
        {
            gameObject.transform.GetChild(itemSelected).GetComponent<Image>().color = unselectedColor;
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
        if (itemSelected != slot - 1) //if an item other than the one currently selected was clicked
        {
            if (itemSelected != -1)
                gameObject.transform.GetChild(itemSelected).GetComponent<Image>().color = unselectedColor; //set previously selected item back to unselected
            itemSelected = slot - 1;
            gameObject.transform.GetChild(slot - 1).GetComponent<Image>().color = selectedColor; //set newly selected item to selected color
        }
        else
        {
            gameObject.transform.GetChild(itemSelected).GetComponent<Image>().color = unselectedColor;
            itemSelected = -1; //set itemSelected to its null value
        }
        
    }
}
