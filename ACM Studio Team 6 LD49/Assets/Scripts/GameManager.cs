using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeToSwitch = 5;
    float timeOfLastSwitch = 0;
    [SerializeField] GameMode _currentGameMode = GameMode.OFFICE;



    public GameMode currentGameMode
    {
        get {return _currentGameMode;}
        private set {_currentGameMode = value;}
    }


    public event System.Action<GameMode> OnChangedGameMode;

    static GameManager _instance;
    public static GameManager instance
    {
        get {return _instance;}
        private set 
        {
            if(_instance != null)
            {
                Debug.LogError("More than one GameManager detected!");
                return;
            }
            _instance = value;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        //instance = null;
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeOfLastSwitch > timeToSwitch)
        {
            Debug.Log("Switching game modes!");

            // "Toggles" game mode
            _currentGameMode = (_currentGameMode == GameMode.OFFICE)? GameMode.FANTASY : GameMode.OFFICE;

            OnChangedGameMode?.Invoke(_currentGameMode);

            timeOfLastSwitch = Time.time;
        }
    }


}

public enum GameMode
{
    OFFICE,
    FANTASY
}
