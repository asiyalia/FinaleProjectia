using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject Pause;
    // Start is called before the first frame update
    private enum GameUI_State
    {
        GamePlay, GamePause
    }
    GameUI_State currentState;
    void Start()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePauseUI();
        }

    }

    private void SwitchUIState(GameUI_State state) 
    {
        Pause.SetActive(false);
        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                break;
            case GameUI_State.GamePause:
                Time.timeScale = 0;
                Pause.SetActive(true);
                break;
        }
    }
    public void TogglePauseUI()
    {
        if(currentState == GameUI_State.GamePlay) 
        {
            SwitchUIState(GameUI_State.GamePause);
        }
        else if (currentState == GameUI_State.GamePause)
        {
            SwitchUIState(GameUI_State.GamePlay);
        }    
    }

    public void Resume()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }    
}
