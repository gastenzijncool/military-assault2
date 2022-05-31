using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject turretFullHealth;
    public GameObject turretHalfhealth;
    //public GameObject turretDestroyed;

    public float health;
    public bool turretIsLow;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        turretHalfhealth.SetActive(false);
        turretFullHealth.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 50 || health < 39)
        {
                turretIsLow = true;
                turretFullHealth.SetActive(false);
        }

        if(health < 0)
        {
            health = 0f;
        }
            
        if (turretIsLow == true)
        {
            turretIsLow = false;
            turretHalfhealth.SetActive(true);
        }

        if(health <= 0)
        {
            turretHalfhealth.SetActive(false);
            //turretDestroyed.SetActive(true);
        }
    }

    public void TakeDamageTurret(int dmg)
    {
        health -= dmg;
    }
}
