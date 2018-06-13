﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
	public Toggle fullscreenToggle; 
	public Dropdown resolutionDropdown; 
	public Dropdown textureQualityDropdown; 
	public Dropdown antialiasingDropdown; 
	public Dropdown vSyncDropdown; 
	public Slider musicVolumeSlider;
	public Button applyButton;
    public Dropdown language; //Added language  changement 02/06
    public bool FR = true;

	public AudioSource musicSource; 
	public Resolution[] resolutions; 
	public GameSettings gameSettings; 

	void OnEnable()
	{
        gameSettings = new GameSettings();

		fullscreenToggle.onValueChanged.AddListener (delegate {onFullscreenToggle (); });
		resolutionDropdown.onValueChanged.AddListener (delegate {onResolutionChange (); });
		textureQualityDropdown.onValueChanged.AddListener (delegate {onTextureQualityChange (); });
		antialiasingDropdown.onValueChanged.AddListener (delegate {onAntialiasingChange (); });
		vSyncDropdown.onValueChanged.AddListener (delegate {onVsyncChange (); });
		musicVolumeSlider.onValueChanged.AddListener (delegate {onMusicVolumeChange (); });
		applyButton.onClick.AddListener (delegate {OnApplyButtonClick(); });
        language.onValueChanged.AddListener(delegate { OnLanguageChanged(); }); //Added language  changement 02/06

        resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) 
		{
			resolutionDropdown.options.Add (new Dropdown.OptionData (resolution.ToString()));
		}

        if (SceneManager.GetActiveScene().name == "Game")
            language.value = FR ? 0 : 1;
		LoadSettings (); 
	}

    public void onFullscreenToggle ()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn; 
	}

	public void onResolutionChange ()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen); 
		gameSettings.resolutionIndex = resolutionDropdown.value; 
	}

	public void onTextureQualityChange ()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value; 
	}

	public void onAntialiasingChange ()
	{
		QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow (2f, antialiasingDropdown.value); 
	}

	public void onVsyncChange ()
	{
		QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value; 
	}

	public void onMusicVolumeChange ()
	{
		musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value; 
	}

	public void OnApplyButtonClick()
	{
		SaveSettings (); 
	}

    //Changer de langue et appelle les scripts de changements de sprites
    public void OnLanguageChanged()
    {
        FR = !FR;
    }


    public void SaveSettings ()
	{
		string jsondata = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsondata);
	}

	public void LoadSettings ()
	{
		musicVolumeSlider.value = gameSettings.musicVolume; 
		antialiasingDropdown.value = gameSettings.antialiasing; 
		vSyncDropdown.value = gameSettings.vSync; 
		textureQualityDropdown.value = gameSettings.textureQuality; 
		resolutionDropdown.value = gameSettings.resolutionIndex; 
		fullscreenToggle.isOn = gameSettings.fullscreen; 
		Screen.fullScreen = gameSettings.fullscreen; 

		resolutionDropdown.RefreshShownValue (); 
	}


}
