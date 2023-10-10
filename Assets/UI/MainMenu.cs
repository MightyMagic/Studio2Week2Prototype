using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject areYouSure;
    public Button play;
    public Button quit;
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    void Start()
    {
        SetActive(areYouSure, false);
        
        // Attach click listeners to buttons
        play.onClick.AddListener(PlayClicked);
        quit.onClick.AddListener(QuitClicked);
        yes.onClick.AddListener(QuitGame);
        no.onClick.AddListener(CloseAreYouSure);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActive(areYouSure, true);
        }
    }

    void SetActive(GameObject obj, bool active)
    {
        obj.SetActive(active);
    }

    void PlayClicked()
    {
        // Load the game scene
        if (PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);
        SceneManager.LoadScene("Game1");
        Debug.Log("Play clicked");
    }

    void QuitClicked()
    {
        SetActive(areYouSure, true);
    }

    void QuitGame()
    {
        if (PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);
        Application.Quit();
        Debug.Log("Quit clicked");
    }

    void CloseAreYouSure()
    {
        SetActive(areYouSure, false);
    }
}
