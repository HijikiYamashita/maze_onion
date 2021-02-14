using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuUIScript : MonoBehaviour
{
    bool pause = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject volumeSetting;

    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider bgmVolumeSlider;
    [SerializeField] Slider seVolumeSlider;

    [SerializeField] AudioMixer mainMixer;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pause == false)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pause = true;
            }

            else if (pause == true)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pause = false;
            }
        }

        mainMixer.SetFloat("MasterVolume", masterVolumeSlider.GetComponent<Slider>().value);
        if (masterVolumeSlider.GetComponent<Slider>().value <= -40)
        {
            mainMixer.SetFloat("MasterVolume", -80);
        }

        mainMixer.SetFloat("BGMVolume", bgmVolumeSlider.GetComponent<Slider>().value);
        if (bgmVolumeSlider.GetComponent<Slider>().value <= -40)
        {
            mainMixer.SetFloat("BGMVolume", -80);
        }

        mainMixer.SetFloat("SEVolume", seVolumeSlider.GetComponent<Slider>().value);
        if (seVolumeSlider.GetComponent<Slider>().value <= -40)
        {
            mainMixer.SetFloat("SEVolume", -80);
        }
    }

    public void onVolumeButton()
    {
        pauseMenuUI.SetActive(false);
        volumeSetting.SetActive(true);
    }
}
