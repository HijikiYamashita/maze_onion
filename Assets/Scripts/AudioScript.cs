using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public int count = 0;

    [SerializeField] GameObject bgm_Walking;
    [SerializeField] GameObject bgm_Stalking;

    void Start()
    {
        bgm();
    }

    void Update()
    {
        
    }

    public void bgm()
    {
        if (count == 0)
        {
            bgm_Stalking.GetComponent<AudioSource>().Stop();
            bgm_Walking.GetComponent<AudioSource>().Play();
        }
        if (count == 1)
        {
            bgm_Walking.GetComponent<AudioSource>().Stop();
            bgm_Stalking.GetComponent<AudioSource>().Play();
        }

    }
}
