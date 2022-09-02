using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isGrounded;
    public bool canDashing;
    public float jumpedFloat;

    public Vector3 jumpPower;

    public void Start()
    {
        canDashing = true;

        jumpPower.y = 9f;
    }
    void Update()
    {
        if(isGrounded && canDashing == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody>().velocity += jumpPower;
                jumpedFloat += 1;

                if(jumpedFloat == 1)
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
