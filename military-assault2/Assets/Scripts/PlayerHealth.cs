using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public float maxHealth = 100;
  public float curHealth = 100;
 
  public float healthBarLength;
  public float damage;
  public float distance;

  public GameObject player;

  public Vector3 velocity;
  public Rigidbody ridgedBody;
  public bool isAlive = true;
  private double decelerationTolerance = 12.0;

  public TextMeshProUGUI healthText;

  public Vector3 enter;
  public Vector3 exit;
 
  // Use this for initialization
  void Start()
  {
    ridgedBody = GetComponent<Rigidbody>();
  }

    // Update is called once per frame
    void Update()
    {
        healthText.text = (curHealth.ToString("f0") + "/" + maxHealth);
        AddjustCurrentHealth(damage);
    }
 
  public void AddjustCurrentHealth(float adj)
  {
    curHealth += adj;
        print(adj);
  
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

