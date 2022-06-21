using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapenSwitch : MonoBehaviour
{
    public GameObject gun;
    public Transform gunTransform;
    public GameObject gunMagazine;

    public GameObject ak;
    public GameObject ak2;
    public GameObject akMagazine;

    public float distanceToAk;
    public bool akPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        ak.SetActive(false);
        gun.SetActive(true);
        akMagazine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gunTransform.position, transform.position);
        distanceToAk = dist;

        if(distanceToAk <= 1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                gunMagazine.SetActive(false);
                akMagazine.SetActive(true);
                akPickedUp = true;
                ak2.SetActive(false);
                ak.SetActive(true);
                gun.SetActive(false);
            } 
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            akMagazine.SetActive(false);
            gunMagazine.SetActive(true);
            gun.SetActive(true);
            ak.SetActive(false);
        }

        if(akPickedUp == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gunMagazine.SetActive(false);
                akMagazine.SetActive(true);
                gun.SetActive(false);
                ak.SetActive(true);
            }
        }  
    }
}
