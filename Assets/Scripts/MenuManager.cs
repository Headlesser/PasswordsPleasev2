using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject[] subMenus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Escape))
        {
            ToggleMenu();
        }
        */
    }

    public void PauseGame()
    {
        ToggleMenu();
    }

    private void ToggleMenu()
    { 
        GameManager.gameManager.paused = !GameManager.gameManager.paused;       
        menu.SetActive(!menu.activeInHierarchy);
    }

    public void OpenSubMenu(int submenu)
    {
        foreach(GameObject obj in subMenus)
        {
            obj.SetActive(false);
            subMenus[submenu].SetActive(true);
        }
    }

    public void CloseGame(int i)
    {
        if (i == 0)
        {
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            Application.Quit();
        }
    }
}
