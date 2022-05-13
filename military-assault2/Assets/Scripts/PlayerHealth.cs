using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public int maxHealth = 100;
  public int curHealth;
 
  public float healthBarLength;
  public float damage;

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
    healthText.SetText(currentHealth + "/" + maxHealth);
    AddjustCurrentHealth(damage);

    if (curHealth == 5)
        {
            Destroy(player);
        }

    if(isAlive == false)
        {
            FallDamage();
        }

  }

  void FixedUpdate() 
    {
        if(isAlive)
        {
            isAlive = Vector3.Distance(ridgedBody.velocity, velocity) < decelerationTolerance;
            velocity = ridgedBody.velocity;
        }
    }
 
  public void AddjustCurrentHealth(int adj)
  {
    curHealth += adj;
  
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

  public void OnCollisionEnter()
  {
    //enter is mijn Vector3
    enter = player.collision.GameObject;
  }

  public void OnCollisionExit()
  {
    //exit is mijn Vector3
    exit = player.collision.GameObject;
  }
}

