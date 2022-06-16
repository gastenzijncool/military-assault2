using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionsMenu;
    public GameObject HUD;
    public GameObject Music;
    public void MainMenu()
    {
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        Music.SetActive(false);
    }
    public void Options()
    {
        Menu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void BackToMenu()
    {
        Menu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

}
