using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] HealthStat playerHealthStat;

    Animator animator;

    void Awake()
    {
        playerHealthStat.OnDeath += HandlePlayerDeath;

        animator = GetComponent<Animator>();
    }


    void HandlePlayerDeath()
    {
        animator.SetTrigger("Start");
    }

    public void Replay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
