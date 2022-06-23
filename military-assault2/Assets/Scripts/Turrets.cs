using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject [] turrets;

    public float health;

    //Gun stats
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsLeft, bulletsShot;
    public float damageTurret;

    //bools 
    bool shooting, reloading;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;

    public GameObject playerObject;

    public Transform player;
    public float distanceToTurret;

    // Start is called before the first frame update
    void Start()
    {
        health = 1000f;
        turrets[1].SetActive(false);
        turrets[2].SetActive(false);
        damageTurret = 5f;
    }
    public void TakeDamageTurret(int dmg)
    {
        health -= dmg;

        if(health < 0)
        {
            health = 0;
        }

        if(health <= 500)
        {
            turrets[0].SetActive(false);
            turrets[1].SetActive(true);
        }

        if(health <= 100)
        {
            turrets[2].SetActive(true);
            turrets[1].SetActive(false);
        }

        if (health <= 0)
        {
            turrets[2].SetActive(false);
        }
    }

    public void Update()
    {
        DistancePlayerAndTurret();

        transform.LookAt(player);

        MyInput();
    }
    void DistancePlayerAndTurret()
    {
        {
            float dist = Vector3.Distance(player.position, transform.position);
            distanceToTurret = dist;
        }
    }
    private void Awake()
    {
        bulletsLeft = magazineSize;
    }
    private void MyInput()
    {
        if(distanceToTurret <= 10)
        {
            shooting = true;
        }

        else
        {
            shooting = false;
        }
        
        if (bulletsLeft == 0)
        {
            Reload();
        }

        //Shoot
        if (shooting && !reloading && bulletsLeft > 0)
        {
            print("I AM SHOOTING");
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        //Raycast
        if (Physics.Raycast(attackPoint.position, transform.forward, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Player"))
            {
                Debug.Log("damageTurret" + damageTurret);
                rayHit.collider.GetComponent<PlayerHealth>().AddjustCurrentHealth(damageTurret);
            }
        }

        //Graphics
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
