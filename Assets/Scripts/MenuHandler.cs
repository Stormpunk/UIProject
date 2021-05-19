using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    bool akmIsActive;
    //Lets me turn off the Any Key Panel upon a button press
    public GameObject AnyKeyPanel;
    //the any key panel
    public GameObject MainMenu;
    //the Main Menu, a doy
    AsyncOperation loadingOperation;
    //loads the scene in the background, actually letting me use the loading screen for like... 0.3 of a second yay!
    public Slider progressBar;

    private void Start()
    {
        //AnyKeyPanel = GameObject.Find("AnyKeyPanel");
        akmIsActive = true;
        //No matter what, when the game starts, the Any Key Menu will be the active one
        //MainMenu = GameObject.Find("MainMenuPanel");
    }

    private void Update()
    {
        if (akmIsActive = true && Input.anyKey)
        {
            AKMtoMain();
            //Triggers the function that goes from the Any Key Menu to the main menu
        }
    }

    public void LoadScene()
    {
        loadingOperation = SceneManager.LoadSceneAsync(1);
        Debug.Log("Game is Play");
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        //loads the game and starts affecting the load screen slider    
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is Quit");
        //quits the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //quits the game in the Unity Editor, actually letting me check if this damn thing works
#endif
    }
    public void FullscreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        //toggles the fullscreen
    }
        void AKMtoMain()
        {
            AnyKeyPanel.SetActive(false);
            MainMenu.SetActive(true);
            akmIsActive = false;
        }
}
