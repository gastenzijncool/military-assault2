using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 movement;
    public float horizontal;
    public float vertical;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public bool isSprinting;
    public bool isWalking;
    public bool isCrouching;
    public Transform cam;
    public bool crouchToggle;
    public bool standingStill;
    public Transform player;
    public RaycastHit hit;
    public float zerospeed;
    public AudioSource walking;

    public Transform cameraPlayer;
    public Transform gun;

    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody3D>();
        crouchSpeed = 2f;
        walkSpeed = 5f;
        sprintSpeed = 7f;
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        movement.x = horizontal;
        vertical = Input.GetAxis("Vertical");
        movement.z = vertical;
        transform.Translate(movement * walkSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            walking.volume = 0.25f;
        }
        else
        {
            walking.volume = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            isWalking = false;
            walkSpeed = 7f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            isWalking = true;
            walkSpeed = 5f;
        }

        //if (Input.GetKey(KeyCode.LeftControl))
        //{
        //   isCrouching = true;
        //    walkSpeed = crouchSpeed;
        //}
        //else
        //{
        //    isCrouching = false;
        //    if (isCrouching == false)
        //    {
        //      if(isSprinting == false)
        //      {
        //        walkSpeed = 5f;
        //      }
        //    }
        //}
        //
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    crouchToggle = true;
        //    if (crouchToggle == true)
        //    {
        //        cameraPlayer.localPosition -= new Vector3(0f, 0.30f, 0f);
        //        gun.localPosition -= new Vector3(0f, 0.30f, 0f);
        //    }
        //
        //}
        //else if(Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //    crouchToggle = false;
        //    cameraPlayer.localPosition += new Vector3(0f, 0.30f, 0f);
        //    gun.localPosition += new Vector3(0f, 0.30f, 0f);
        //}
    }// lelijke code!
    // Gemaakt door dariel nog, L
    
}

