using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndTheGame());
    }

    IEnumerator EndTheGame()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
        if (PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);
    }
}
