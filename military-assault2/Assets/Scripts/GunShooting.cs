using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShooting : MonoBehaviour
{
    //Gun stats
    public float timeBetweenShooting, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public int damageGun;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI text;
    public AudioSource gunShot;
    public AudioSource gunReload;
    public ParticleSystem gun;

    public GameObject enemy, turret;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        if (CanvasScript.menuON == true || Esc.menuON == true)
        {
            return;
        }
           
        MyInput();
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }

        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        if(bulletsLeft == 0)
        {
            Reload();
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
            gunShot.PlayOneShot(gunShot.clip);
            //gunShot.volume = 1f;
            gun.Play();
            
        }
       // else
       // {
        //    gunShot.volume = 0f;
       // }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Raycast
        if (Physics.Raycast(attackPoint.transform.position, transform.forward, out rayHit, range))
        {
           Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                //Debug.Log("damageGun" + damageGun);
                rayHit.collider.GetComponent<EnemyHealth2>().TakeDamage(damageGun);
            }

            if (rayHit.collider.CompareTag("Turret"))
            {
                //Debug.Log("damageGun" + damageGun);
                rayHit.collider.GetComponent<Turrets>().TakeDamageTurret(damageGun);
            }
        }

        //Graphics
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
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
        gunReload.Play();
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}