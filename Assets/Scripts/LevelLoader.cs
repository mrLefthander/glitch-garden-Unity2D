using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceeneIndex;
    private void Start()
    {
        currentSceeneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceeneIndex == 0)
        {
            StartCoroutine(WaitAndLoadScene());
        }
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceeneIndex+1);
    }

    public void LoadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceeneIndex);
    }

/*    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadSceneByName("Game Over"));
    }*/

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3f);
        LoadNextScene();
    }

    IEnumerator WaitAndLoadSceneByName(string scene)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }
}
