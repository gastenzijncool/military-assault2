using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Magazine;
    public GameObject Crosshair;
    public void MainMenu()
    {
        Menu.SetActive(false);
        Magazine.SetActive(true);
        Crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
