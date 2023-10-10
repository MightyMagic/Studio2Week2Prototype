using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;

    [SerializeField] float coordinateToDie;
    [SerializeField] GameObject targetSphere;
    private Vector3 startRedSpherePosition;
    [SerializeField] float redSphereReloadDistance;

    [SerializeField] GameObject FinalCanvas;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Room"))
            PlayerPrefs.SetInt("Room", 0);

        startRedSpherePosition = targetSphere.transform.position;
    }

    private void Start()
    {
        cam.enabled= false;
        player.transform.position = spawnPoints[PlayerPrefs.GetInt("Room")].transform.position;
        cam.enabled = true;

        FinalCanvas.SetActive(false);
    }

    void Update()
    {
        if(player.transform.position.y < coordinateToDie || Mathf.Abs(targetSphere.transform.position.y - startRedSpherePosition.y) > redSphereReloadDistance)
        {
            Reload();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("Game1");
    }

    public void GameOver()
    {
        FinalCanvas.SetActive(true);
    }
}
