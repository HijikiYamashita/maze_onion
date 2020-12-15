using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class onionsScript : MonoBehaviour
{
    public int speed;

    GameObject player;

    [SerializeField] bool stalking = false;

    void Start()
    {
        player = GameObject.Find("Player");
        transform.Find("AroundCollider").gameObject.SetActive(false);
    }

    void Update()
    {
        if (stalking == true)
        {
            this.gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.Find("AroundCollider").gameObject.SetActive(true);
            stalking = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.Find("AroundCollider").gameObject.SetActive(false);
            Invoke("stalkingOff", 1);
        }
    }

    void stalkingOff()
    {
        stalking = false;
    }
}
