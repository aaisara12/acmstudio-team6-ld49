using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] GameObject creditsUI;
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenCredits()
    {
        creditsUI.SetActive(true);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            creditsUI.SetActive(false);
        }
    }
}
