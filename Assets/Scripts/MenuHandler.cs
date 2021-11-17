using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    AsyncOperation loadingOperation;
    public GameObject anyKeyScreen;
    public bool anyKeyActive;
    public Slider progressBar;
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNext()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
        Debug.Log("GameIsPlay");
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ExitZeGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterAudio", Mathf.Log10 (volume) *20) ;
    }
    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
    }
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Toggling Fullscreen");
    }
}
