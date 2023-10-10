using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        if (PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);
    }
    public void QuitGame()
    {
        if (PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);
        Application.Quit();
    }
    
}
