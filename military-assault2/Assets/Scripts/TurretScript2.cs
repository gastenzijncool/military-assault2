using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript2 : MonoBehaviour
{
    public float health;

    public float magazine = 50;

    public Transform player;

    public float distanceToTurret;

    public float damageGun;

    // Start is called before the first frame update
    void Start()
    {
        health = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);
        transform.LookAt(new Vector3 (player.position.x, transform.position.y, transform.position.z));


        float dist = Vector3.Distance(player.position, transform.position);
        distanceToTurret = dist;

        if(distanceToTurret <= 10)
        {
            magazine -= Time.deltaTime;
        }
        
        if(magazine < 0)
        {
            magazine = 0;
        }

        if(magazine > 0)
        {
            GetComponent<PlayerHealth>().AddjustCurrentHealth(damageGun);
        }

    }
}
