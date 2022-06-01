using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject [] turrets;

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        turrets[1].SetActive(false);
        turrets[2].SetActive(false);
    }

    public void TakeDamageTurret(int dmg)
    {
        health -= dmg;

        if(health <= 50)
        {
            turrets[0].SetActive(false);
            turrets[1].SetActive(true);
        }

        if(health <= 0)
        {
            turrets[2].SetActive(true);
            turrets[1].SetActive(false);
        }
    }
}
