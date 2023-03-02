using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    private bool isPaused;
    private bool isPlayerActive;
    public bool isMainScene;

    private void Start()
    {
        if (isMainScene)
        {
            isPlayerActive = true;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isMainScene)
        {
            PauseGame();
        }
    }

    //Title scene
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    //Main scene = Start game
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");

        Time.timeScale = 1;
        isPaused = false;
        isPlayerActive = true;
    }

    //Restart game
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");

        Time.timeScale = 1;
        isPaused = false;
        isPlayerActive = true;

        SoundManager.Instance.PlaySound(SoundManager.mySounds.gateOpen);
    }

    //Game Over
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        SoundManager.Instance.PlaySound(SoundManager.mySounds.gateClose);



        //Load game over scene
        /*if (!SceneManager.GetSceneByName("GameOver").isLoaded)
        {
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
            SoundManager.Instance.PlaySound(SoundManager.mySounds.gateClose);

            //Stop player actions
            Time.timeScale = 0f;
            isPlayerActive = false;

        }
        else if (SceneManager.GetSceneByName("GameOver").isLoaded)
        {
            SceneManager.UnloadSceneAsync("GameOver");
            SoundManager.Instance.PlaySound(SoundManager.mySounds.gateOpen);

            //Stop player actions
            Time.timeScale = 1f;
            isPlayerActive = true;
        }
        */



    }

    //Pause
    public void PauseGame()
    {
        if (isPaused && isPlayerActive)
        {
            SceneManager.UnloadSceneAsync("Pause");

            Time.timeScale = 1;
            isPaused = false;
        }
        else if (!isPaused && isPlayerActive)
        {
            if (SceneManager.GetSceneByName("Pause").isLoaded == false)
            {
                SceneManager.LoadSceneAsync("Pause", LoadSceneMode.Additive);

                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }



    //Quit
    public void QuitGame()
    {
        Application.Quit();
    }

}
