using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public bool mayDash;
    private float mayDashTrueTimer;
    private float canDashTrueTimer;

    private void Start()
    {
        mayDash = true;

        mayDashTrueTimer = 3f;
        canDashTrueTimer = 0.3f;

        dashSpeed = 25f;     
    }
    private void Update()
    {
        if (mayDash == true)
        {
            if(GameObject.Find("player").GetComponent<PlayerJump>().isGrounded) 
            {
                if (Input.GetButtonDown("F"))
                {
                    GetComponent<Rigidbody>().drag = 4;

                    mayDash = false;

                    GameObject.Find("player").GetComponent<PlayerJump>().canDashing = false;

                    GetComponent<Rigidbody>().velocity += transform.forward * dashSpeed;

                    Invoke("MayDashTrue", mayDashTrueTimer);
                    Invoke("CanDash", canDashTrueTimer);
                }
            }   
        }    
    }
    private void MayDashTrue()
    {
        mayDash = true;
    }
    private void CanDash()
    {
        GameObject.Find("player").GetComponent<PlayerJump>().canDashing = true;

        GetComponent<Rigidbody>().drag = 1;
    }
}

