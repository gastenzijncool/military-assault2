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
    bool readyToShoot;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;

    //Graphics
    public GameObject muzzleFlash;

    public GameObject playerObject;
    public GameObject turret;
    public AudioSource gunShot;
    public AudioSource gunReload;
    public ParticleSystem muzzle;

    public Transform player;
    public float distanceToTurret;

    // Start is called before the first frame update
    void Start()
    {
        health = 1000f;
        turrets[1].SetActive(false);
        turrets[2].SetActive(false);
        damageTurret = 5f;
        magazineSize = 5;
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
            damageTurret = 3f;
        }

        if(health <= 100)
        {
            turrets[2].SetActive(true);
            turrets[1].SetActive(false);
            damageTurret = 1f;
        }

        if (health <= 0)
        {
            Destroy(turret);
            damageTurret = 0f;
        }
    }

    public void Update()
    {
        DistancePlayerAndTurret();

        transform.LookAt(player);
        Vector3 angles = transform.localEulerAngles;
        angles.x = 0;
        transform.localEulerAngles = angles;

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
        readyToShoot = true;
    }
    private void MyInput()
    {
        if(distanceToTurret <= 14)
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
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
            gunShot.Play();
            muzzle.Play();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        PlayerHealth playerHealth = GameObject.Find("player").GetComponent<PlayerHealth>();
        //Raycast
        if (Physics.Raycast(attackPoint.position, transform.forward, out rayHit, range))
        {
            if (rayHit.collider.CompareTag("Player"))
            {   
                playerHealth.AddjustCurrentHealth(damageTurret);
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

    private void ResetShot()
    {
        readyToShoot = true;
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
