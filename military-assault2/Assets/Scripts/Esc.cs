using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject optionsMenu;
    public GameObject hud;

    public static bool escMenuON;

    private void Start()
    {
        escMenuON = true;
    }
    public void Back()
    {
        optionsMenu.SetActive(false);
        escMenu.SetActive(true);
        escMenuON = true;
    }
    public void EscBack()
    {
        escMenu.SetActive(false);
        hud.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.SetActive(true);
            hud.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
