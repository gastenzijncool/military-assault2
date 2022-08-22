using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isGrounded;
    public float jumpedFloat;

    public Vector3 jumpPower;

    public void Start()
    {
        //jumpPower.y = 5;
    }
    void Update()
    {
        if(isGrounded == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody>().velocity += jumpPower;
                jumpedFloat += 1;

                if(jumpedFloat == 2)
                {
                    isGrounded = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Untagged")
        {
            isGrounded = true;
            jumpedFloat = 0;
        }
    }
}
