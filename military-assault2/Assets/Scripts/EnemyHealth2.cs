using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public float health;
    public int damage;

    public GameObject bulletHoleGraphic;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
