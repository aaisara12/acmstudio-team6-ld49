using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausePanel.activeSelf)
                Resume();
            else
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
            
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackToStart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
