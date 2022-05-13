using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public int maxHealth = 100;
  public int curHealth = 100;
 
  public float healthBarLength;
  public int damage;
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
    healthText.SetText(curHealth + "/" + maxHealth);
        AddjustCurrentHealth(damage);
        if(distance < 2 || distance > 4)
        {
            curHealth = 10;
        }

        if (distance < 4 || distance > 6)
        {
            curHealth = 30;
        }

        if (distance < 6 || distance > 8)
        {
            curHealth = 50;
        }

        if (curHealth == 20)
        {
            Destroy(player);
        }

    if(isAlive == false)
        {
           
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
    enter = player.transform.position;
        distance = Vector3.Distance(enter, exit);
  }

  public void OnCollisionExit()
  {
    //exit is mijn Vector3
    exit = player.transform.position;
  }
}

