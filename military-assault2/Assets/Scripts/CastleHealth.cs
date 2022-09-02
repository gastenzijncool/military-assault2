using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    public float poortHP;
    void Start()
    {
        poortHP = 10000f;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Poort")
        {
            poortHP -= 30 * Time.deltaTime;
        }
    }
}
