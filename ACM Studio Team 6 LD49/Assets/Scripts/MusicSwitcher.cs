using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] AudioSource officeMusic;
    [SerializeField] AudioSource fantasyMusic;
    // Start is called before the first frame update
    void Start()
    {
        officeMusic.volume = 1;
        fantasyMusic.volume = 0;
        GameManager.instance.OnChangedGameMode += HandleNewGameMode;
    }

    void HandleNewGameMode(GameMode gameMode)
    {
        switch(gameMode)
        {
            case GameMode.OFFICE:
                officeMusic.volume = 1;
                fantasyMusic.volume = 0;
                break;
            case GameMode.FANTASY:
                officeMusic.volume = 0;
                fantasyMusic.volume = 1;
                break;
            default:
                break;
        }
    }
}
