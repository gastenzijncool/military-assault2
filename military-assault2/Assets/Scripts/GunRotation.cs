using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float sensitivity = 200f;

    public float xRotation = 0f;
    public float yRotation = 0f;

    public Transform gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, 0f, 0f);
        yRotation = Mathf.Clamp(xRotation, 180f, 180f);

        gun.localRotation = Quaternion.Euler(xRotation, 180f, 0f);
        gun.Rotate(Vector3.up * mouseX);
    }
}
