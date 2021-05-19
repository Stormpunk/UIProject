using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Camera;
    bool Paused = false;
    // Start is called before the first frame update
    void Start()
    {
       // Canvas.gameObject.SetActive(false);
       //this is very useful but it turns off the game scene's panel too which we can't have
    }

    // Update is called once per frame
    void Update()
    {
        if (PausePanel.gameObject == false)
        {
            Paused = false;
        }
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                PausePanel.gameObject.SetActive(false);
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
                Paused = false;
                //resumes the game if paused when pressing esc


            }
            else
            {
                Time.timeScale = 0.0f;
                PausePanel.gameObject.SetActive(true);
               //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.Confined;
                Paused = true;
                //pauses the game if not paused when pressing esc
            }
        }
    }
}
