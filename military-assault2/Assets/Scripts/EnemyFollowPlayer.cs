using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform enemy;
    public Transform player;

    public float speed = 0.05f;
    public float distanceToPlayer;

    Rigidbody rig;

    public Vector3 movement;
    public float horizontal;
    public float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        distanceToPlayer = dist;

        horizontal = Input.GetAxis("Horizontal");
        movement.x = horizontal;
        vertical = Input.GetAxis("Vertical");
        movement.z = vertical;

        if(distanceToPlayer <= 10)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
       
        transform.LookAt(player);
    }
}
