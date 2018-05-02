using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	public Toggle fullscreenToggle; 
	public Dropdown resolutionDropdown; 
	public Dropdown textureQualityDropdown; 
	public Dropdown antialiasingDropdown; 
	public Dropdown vSyncDropdown; 
	public Slider musicVolumeSlider;
	public Button applyButton; 

	public AudioSource musicSource; 
	public Resolution[] resolutions; 
	public GameSettings gameSettings; 

	void OnEnable()
	{
        gameSettings = new GameSettings ();

		fullscreenToggle.onValueChanged.AddListener (delegate {onFullscreenToggle (); });
		resolutionDropdown.onValueChanged.AddListener (delegate {onResolutionChange (); });
		textureQualityDropdown.onValueChanged.AddListener (delegate {onTextureQualityChange (); });
		antialiasingDropdown.onValueChanged.AddListener (delegate {onAntialiasingChange (); });
		vSyncDropdown.onValueChanged.AddListener (delegate {onVsyncChange (); });
		musicVolumeSlider.onValueChanged.AddListener (delegate {onMusicVolumeChange (); });
		applyButton.onClick.AddListener (delegate {OnApplyButtonClick(); });

		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) 
		{
			resolutionDropdown.options.Add (new Dropdown.OptionData (resolution.ToString()));
		}

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

	public void SaveSettings ()
	{
		string jsondata = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsondata);
	}

	public void LoadSettings ()
	{
		/*gameSettings = JsonUtility.FromJson<GameSettings> (File.ReadAllText(Application.persistentDataPath + "/gamesettings.json")); */

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
