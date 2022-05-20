using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isGrounded;

    public Vector3 jumpPower;

    public int falldamagetime;
    public int multiplier;

    public LayerMask mask;

    public float jumpTimeFloat;

    public void Start()
    {
        jumpPower.y = 5;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), .5f, mask);    
        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded==true)
            {
                GetComponent<Rigidbody>().velocity += jumpPower;
                jumpTimeFloat = 0;
            }
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            jumpTimeFloat += 1 * Time.deltaTime;
        }

        else if (isGrounded == true && jumpTimeFloat > falldamagetime)
        {
            GetComponent<PlayerHealth>().AddjustCurrentHealth(-(multiplier * jumpTimeFloat - falldamagetime));
        }
    }
}
