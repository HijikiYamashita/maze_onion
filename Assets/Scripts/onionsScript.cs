using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onionsScript : MonoBehaviour
{
    public int speed;

    bool stalking = false;
    public bool a = false;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            stalking = true;
        }
    }
}
