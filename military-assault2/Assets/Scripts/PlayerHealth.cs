using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public float maxHealth = 200;
  public float curHealth = 200;
 
  public GameObject player;
  public Transform medkid;
  public GameObject medkitGameObject;
  public GameObject gameOver; 
  public bool slurpjuice;
  public float slurpjuiceTime = 5;

  public TextMeshProUGUI healthText;
  public GameObject PressE;
  public bool PressedE;

  public float distanceToMedkid;

    private void Start()
    {
        PressedE = false;
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = (curHealth.ToString("f0") + "/" + maxHealth);

        if(curHealth == 0)
        {
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        float dist = Vector3.Distance(medkid.position, transform.position);
        distanceToMedkid = dist;

        if (distanceToMedkid <= 2)
        {
            PressedE = true;
            if( PressedE == true)
            {
                PressE.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                slurpjuice = true;
                Invoke("SlurpjuiceBoolean", slurpjuiceTime);

                medkitGameObject.SetActive(false);
            }
        }

        if (slurpjuice == true)
        {
            curHealth += 10f * Time.deltaTime;
        }

        if (curHealth > 100)
        {
            slurpjuice = false;
        }
    }
  private void SlurpjuiceBoolean()
    {
        slurpjuice = false;
    }
 
  public void AddjustCurrentHealth(float adj)
  {
    Debug.Log(adj);
    curHealth -= adj;
  
    if (curHealth < 0)
    {
      curHealth = 0;
    }
  
    if (curHealth > maxHealth)
    {
      curHealth = maxHealth;
    }
    
    if (maxHealth < 1)
    {
      maxHealth = 1;
    }

    if (curHealth > 100)
    {
      curHealth = 100;
    }
  }
}

