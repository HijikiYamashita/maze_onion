using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    int item = 0;

    public GameObject snowman;

    AudioSource audioSource;

    [SerializeField] AudioClip se_busgasexplosion;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("onions"))
                {
                    Destroy(hit.collider.gameObject);
                    audioSource.PlayOneShot(se_busgasexplosion);
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
        if (col.gameObject.tag == "item")
        {
            if(col.gameObject.name == "Snowman")
            {
                item = 1;
                Destroy(col.gameObject);
                snowman.SetActive(true);
            }
            if (col.gameObject.name == "Hammer")
            {
                item = 1;
                Destroy(col.gameObject);
                snowman.SetActive(true);
            }
        }
    }
}
