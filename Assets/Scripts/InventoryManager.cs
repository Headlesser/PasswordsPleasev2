using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager invManager;

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
            //DontDestroy(gameObject);
        }
    }

    public void UpdateInventoryUI()
    {
        int i = 0;
        foreach (PickUpable item in GameManager.ins.Inventory)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = item.sprite;
            i++;
            if (i > transform.childCount)
                break;
        }
    }

    // void Update()
    // {
    //     UpdateInventoryUI();
    // }
}
