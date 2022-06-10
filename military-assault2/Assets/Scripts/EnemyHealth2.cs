using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public float health;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        //print(dmg);

        if (health <= 0)
        {
            Destroy(gameObject);
            //Destroy(bulletHoleGraphic);
        }
    }
}
