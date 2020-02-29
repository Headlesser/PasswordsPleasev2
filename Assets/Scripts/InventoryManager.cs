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
        }
    }

    public void UpdateInventoryUI()
    {
        int i = 0;
        foreach (GameObject item in GameManager.gameManager.Inventory)
        {
            print(gameObject.transform.GetChild(i));
            gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = item.GetComponent<PickUpable>().sprite;
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
            i++;
            if (i > transform.childCount)
                break;
        }
    }
}
