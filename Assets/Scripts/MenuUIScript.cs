using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class SaveData
{
    public float masterVolume;
    public float bgmVolume;
    public float seVolume;
}

public class MenuUIScript : MonoBehaviour
{
    bool pause = false;

    /*SaveData saveData = new SaveData();
    string settingJson;
    const string SAVE_FILE_PATH = "save.txt";*/

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject volumeSetting;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider bgmVolumeSlider;
    [SerializeField] Slider seVolumeSlider;
    [SerializeField] AudioMixer mainMixer;
    
    void Awake()
    {
        loadSetting();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pause == false)
            {
                uiReset();
                pauseMenuUI.SetActive(true);
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                loadSetting();
                Time.timeScale = 0;
                pause = true;
            }

            else if (pause == true)
            {
                uiReset();
                pauseMenuUI.SetActive(true);
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                saveSetting();
                Time.timeScale = 1;
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

    public void onApplyButton()
    {
        saveSetting();
        uiReset();
        pauseMenuUI.SetActive(true);
    }

    public void onCancelButton()
    {
        loadSetting();
        uiReset();
        pauseMenuUI.SetActive(true);
    }

    public void onReturnGameButton()
    {
        uiReset();
        pauseMenuUI.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        saveSetting();
        Time.timeScale = 1;
        pause = false;
    }

    public void onReturnTitleButton()
    {
        Time.timeScale = 1;
        saveSetting();
        Debug.Log("タイトル画面まだ作ってねえええ");
    }

    public void onQuitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void onVolumeButton()
    {
        uiReset();
        volumeSetting.SetActive(true);
    }

    void uiReset()
    {
        pauseMenuUI.SetActive(false);
        volumeSetting.SetActive(false);
    }

    void saveSetting()
    {
        /*saveData.masterVolume = masterVolumeSlider.GetComponent<Slider>().value;
        saveData.bgmVolume = bgmVolumeSlider.GetComponent<Slider>().value;
        saveData.seVolume = seVolumeSlider.GetComponent<Slider>().value;

        settingJson = JsonUtility.ToJson(saveData);

        string path = Application.dataPath + "/" + SAVE_FILE_PATH;
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(saveData);
        writer.Flush();
        writer.Close();*/

        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("SEVolume", seVolumeSlider.GetComponent<Slider>().value);
    }

    void loadSetting()
    {
        masterVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVolume", 0);
        bgmVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGMVolume", 0);
        seVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SEVolume", 0);
    }
}