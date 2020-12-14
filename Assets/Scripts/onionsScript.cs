using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onionsScript : MonoBehaviour
{
    public int speed;

    //bool stalking = false;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        int distance = 1;

        Debug.DrawLine(transform.position, transform.forward * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("あたた");
            }
        }
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            stalking = true;
            Debug.Log("あたた");
        }
    }*/
}
