using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class onionsScript : MonoBehaviour
{
    public float walkSpeed;
    public float dashSpeed;

    public GameObject[] points;
    [SerializeField] int pointsNum;
    private int random;

    private float timer;

    [SerializeField] int autoStalkingTime;
    [SerializeField] int pointChangeTime;

    [SerializeField] LayerMask mask;

    private GameObject player;

    private bool stalking = false;

    void Start()
    {
        random = Random.Range(0, pointsNum);
        player = GameObject.Find("Player");
        gameObject.GetComponent<NavMeshAgent>().destination = points[random].transform.position;
        gameObject.GetComponent<NavMeshAgent>().speed = walkSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (stalking == true)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
        else if (stalking == false)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = points[random].transform.position;
            if (timer >= pointChangeTime)
            {
                random = Random.Range(0, pointsNum);
                timer = 0;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && !Physics.Linecast(transform.position + Vector3.up,col.transform.position + Vector3.up,mask))
        {
            gameObject.GetComponent<NavMeshAgent>().speed = dashSpeed;
            stalking = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("stalkingOff", autoStalkingTime);
        }
    }

    void stalkingOff()
    {
        this.gameObject.GetComponent<NavMeshAgent>().speed = walkSpeed;
        stalking = false;
    }
}
