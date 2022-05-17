using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isGrounded;
    public Vector3 jumpPower;
    public float jumptime;
    public float falldamagetime;
    public float multiplier;
    public LayerMask mask;

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), .5f, mask);    
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded==true)
            {
                isGrounded = false;
                GetComponent<Rigidbody>().velocity += jumpPower;
                jumptime = 0;
            }
        }

        if (!isGrounded)
        {
            jumptime += Time.deltaTime;
        }

        else if (isGrounded && jumptime > falldamagetime)
            GetComponent<PlayerHealth>().AddjustCurrentHealth(-(multiplier * jumptime -falldamagetime));
    }
}
