using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    public float distanceToHangar;
    public Transform hangar;
    public GameObject winGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(hangar.position, transform.position);
        distanceToHangar = dist;

        if(distanceToHangar <= 2)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                winGame.SetActive(true);
            }
        }
        
    }
}
