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
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public int damageGun;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public float camShakeMagnitude, camShakeDuration;

    public GameObject playerObject;

    public Transform player;
    public float distanceToTurret;

    // Start is called before the first frame update
    void Start()
    {
        health = 1000f;
        turrets[1].SetActive(false);
        turrets[2].SetActive(false);
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

        if(health <= 0)
        {
            turrets[2].SetActive(true);
            turrets[1].SetActive(false);
        }
    }

    public void Update()
    {
        DistancePlayerAndTurret();
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
        if (allowButtonHold) shooting = (distanceToTurret <= 20);
        else shooting = (distanceToTurret <= 20);

        if (bulletsLeft == 0)
        {
            Reload();
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //Raycast
        //EnemyHealth2 enemyHealth2 = GameObject.Find("Enemy").GetComponent<EnemyHealth2>();
        //Turrets turrets = GameObject.Find("Turrets").GetComponent<Turrets>();

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Player"))
            {
                Debug.Log("damageGun" + damageGun);
                rayHit.collider.GetComponent<PlayerHealth>().AddjustCurrentHealth(damageGun);
            }
        }

        //Graphics
        Graphics();

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
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

    public void Graphics()
    {
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
    }
}
