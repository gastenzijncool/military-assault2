using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionsMenu;
    public GameObject Magazine;
    public GameObject Crosshair;
    public void MainMenu()
    {
        Menu.SetActive(false);
       // Magazine.SetActive(true);
       // Crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
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
