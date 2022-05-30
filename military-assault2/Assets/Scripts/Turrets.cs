using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject turretFullHealth;
    public GameObject turretHalfhealth;

    public float health;
    public bool isTurretLow;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        //Instantiate(turretFullHealth, new Vector3(8f, 4f, 16f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            health -= 10f;
            if (health <= 50)
            {
                isTurretLow = true;
                Destroy(turretFullHealth);
            }
        }
            
        if (isTurretLow == true)
        {
            isTurretLow = false;
            Instantiate(turretHalfhealth, new Vector3(11f, 4f, 11f), Quaternion.identity);
        }

        if(health <= 0)
        {
            Destroy(turretHalfhealth);
        }
    }
}
