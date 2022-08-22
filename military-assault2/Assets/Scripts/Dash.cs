using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody rb;

    private float dashSpeed;
    public bool mayDash;

    private float mayDashTrueTimer;

    private void Start()
    {
        mayDash = true;
        dashSpeed = 700f;

        mayDashTrueTimer = 3f;
    }
    private void Update()
    {
        if(mayDash == true)
        {
            if (Input.GetButtonDown("F"))
            {
                print("Dash Me Daddyyyy");
                mayDash = false;

                rb.AddForce(transform.forward * dashSpeed);

                Invoke("MayDashTrue", mayDashTrueTimer);
            }
        }    
    }
    private void MayDashTrue()
    {
        mayDash = true;
    }
}

