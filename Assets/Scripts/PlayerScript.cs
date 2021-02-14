using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    int item = 0;
    [SerializeField] GameObject[] itemUI;

    AudioSource audioSource;
    [SerializeField] AudioClip[] se;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (item == 1)//死人
            {
                itemUI[1].SetActive(false);
                item = 0;
            }
            if (item == 2)//ハンマー
            {
                Ray ray = new Ray();
                RaycastHit hit = new RaycastHit();
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.CompareTag("onions"))
                    {
                        audioSource.PlayOneShot(se[0]);
                        hit.collider.gameObject.GetComponent<onionsScript>().stalkingOff();
                        Destroy(hit.collider.gameObject);
                        itemUI[2].SetActive(false);
                        item = 0;
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "onions")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Goal")
        {
            SceneManager.LoadScene("GameClear");
        }

        if (col.gameObject.tag == "item")
        {
            itemUIReset();
            if(col.gameObject.name == "Snowman")
            {
                item = 1;
                Destroy(col.gameObject);
                itemUI[1].SetActive(true);
            }
            if (col.gameObject.name == "Hammer")
            {
                item = 2;
                Destroy(col.gameObject);
                itemUI[2].SetActive(true);
            }
        }
    }

    void itemUIReset()
    {
        itemUI[1].SetActive(false);
        itemUI[2].SetActive(false);
    }
}
