using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public float health;

    public GameObject Enemy;
    public GameObject bulletHoleGraphic;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(Enemy);
            //Destroy(bulletHoleGraphic);
        }
    }

    public void TakeDamage()
    {
        health -= 20;
    }
}
