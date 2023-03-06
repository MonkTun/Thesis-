using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;

    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider scrollSensitivitySlider;
    [SerializeField] private Slider fontSizeSlider;
    [SerializeField] private Toggle progressIndicatorOnRightToggle;
    [SerializeField] private Toggle leaveButtonOnLeftToggle;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        LoadSettings();
    }

    public void DebugReset()
    {
        ProgressManager.Instance.ResetProgress();
    }


    public void LoadSettings()
    {
        float sfxVolume = ES3.Load("settings_sfxVolume", 0.5f);
        Settings.SetSFXVolume(sfxVolume);
        sfxVolumeSlider.value = sfxVolume;
        
        float scrollSensitivity = ES3.Load("settings_scrollSensitivity", 20f);
        Settings.SetScrollSensitivity(scrollSensitivity);
        scrollSensitivitySlider.value = scrollSensitivity;

        bool progressIndicatorOnRight = ES3.Load("settings_progressIndicatorOnRight", true);
        Settings.SetProgressIndicatorOnRight(progressIndicatorOnRight);
        progressIndicatorOnRightToggle.isOn = progressIndicatorOnRight;
        
        bool leaveButtonOnLeft = ES3.Load("settings_leaveButtonOnLeft", true);
        Settings.SetLeaveButtonOnLeft(leaveButtonOnLeft);
        leaveButtonOnLeftToggle.isOn = leaveButtonOnLeft;
    }
    
    public void SetSFXVolume(float value)
    {
        ES3.Save("settings_sfxVolume", value);
        Settings.SetSFXVolume(value);
    }
    
    public void SetScrollSensitivity (float value)
    {
        ES3.Save("settings_scrollSensitivity", value);
        Settings.SetScrollSensitivity(value);

        LobbyManager lobbyManager = FindObjectOfType<LobbyManager>();

        if (lobbyManager != null)
        {
            lobbyManager.SetScrollSensitivity();
        }
    }

    public void SetProgressIndicatorOnRight(bool value)
    {
        ES3.Save("settings_progressIndicatorOnRight", value);
        Settings.SetProgressIndicatorOnRight(value);
    }
    
    public void SetLeaveButtonOnLeft(bool value)
    {
        ES3.Save("settings_leaveButtonOnLeft", value);
        Settings.SetLeaveButtonOnLeft(value);
    }
}
