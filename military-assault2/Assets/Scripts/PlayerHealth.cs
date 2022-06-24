using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public float maxHealth = 100;
  public float curHealth = 100;
 
  public GameObject player;
  public Transform medkid;
  public GameObject medkitGameObject;

  public TextMeshProUGUI healthText;

  public float distanceToMedkid;

    // Update is called once per frame
    void Update()
    {
        healthText.text = (curHealth.ToString("f0") + "/" + maxHealth);

        if(curHealth == 0)
        {
            player.SetActive(false);
        }

        float dist = Vector3.Distance(medkid.position, transform.position);
        distanceToMedkid = dist;

        if (distanceToMedkid <= 1.5)
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                curHealth = 100f;
                medkitGameObject.SetActive(false);
            }
        }
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

