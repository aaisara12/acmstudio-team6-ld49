using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text modeText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnChangedGameMode += HandleNewGameMode;
        HandleNewGameMode(GameManager.instance.currentGameMode);
    }


    void HandleNewGameMode(GameMode newMode)
    {
        modeText.text = "MODE: " + newMode.ToString();
    }
}
