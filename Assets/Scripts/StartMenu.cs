using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartFresh() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToGalleryMenu()
    {
        SceneManager.LoadScene("GalleryMenu");
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
