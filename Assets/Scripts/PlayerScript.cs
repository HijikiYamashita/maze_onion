using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    int item = 0;

    public GameObject snowmanUI;
    public GameObject hammerUI;

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
            if (item == 1)//雪だるま
            {
                snowmanUI.SetActive(false);
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
                        audioSource.PlayOneShot(se_busgasexplosion);
                        Destroy(hit.collider.gameObject);
                        hammerUI.SetActive(false);
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
            Debug.Log("Iaug/#IV");
            SceneManager.LoadScene("GameClear");
        }

        if (col.gameObject.tag == "item")
        {
            if(col.gameObject.name == "Snowman")
            {
                item = 1;
                Destroy(col.gameObject);
                snowmanUI.SetActive(true);
            }
            if (col.gameObject.name == "Hammer")
            {
                item = 2;
                Destroy(col.gameObject);
                hammerUI.SetActive(true);
            }
        }
    }
}
