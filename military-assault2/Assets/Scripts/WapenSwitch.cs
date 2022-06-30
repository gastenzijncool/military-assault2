using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapenSwitch : MonoBehaviour
{
    public GameObject gun;
    public Transform gunTransform;
    public Transform akTransform;
    public GameObject gunMagazine;

    public GameObject ak;
    public GameObject ak2;
    public GameObject akMagazine;

    public GameObject c4Remote;

    public float distanceToAk;
    public bool akPickedUp;

    public float distanceToC4;
    public Transform c4;
    public GameObject winGame;
    public bool remoteInHand;

    // Start is called before the first frame update
    void Start()
    {
        ak.SetActive(false);
        gun.SetActive(true);
        akMagazine.SetActive(false);
        c4Remote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(akTransform.position, transform.position);
        distanceToAk = dist;

        float distC4 = Vector3.Distance(c4.position, transform.position);
        distanceToC4 = distC4;

        if (distanceToAk <= 2)
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
            c4Remote.SetActive(false);
            remoteInHand = false;
        }

        if(akPickedUp == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gunMagazine.SetActive(false);
                akMagazine.SetActive(true);
                gun.SetActive(false);
                ak.SetActive(true);
                c4Remote.SetActive(false);
                remoteInHand = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            c4Remote.SetActive(true);
            gun.SetActive(false);
            ak.SetActive(false);
            gunMagazine.SetActive(false);
            akMagazine.SetActive(false);
            remoteInHand = true;
        }

        if (distanceToC4 <= 10)
        {
            if(remoteInHand == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    winGame.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }  
        }
    }
}
