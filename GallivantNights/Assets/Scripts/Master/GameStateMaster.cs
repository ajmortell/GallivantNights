using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameStateMaster : Singleton<GameStateMaster>
{

    private int last_scene = 0;
    private int last_option = 0;
    private int last_line = 0;

    private enum GameState { NONE = 0, STARTUP = 1, SPLASH = 2, CUT = 3, GAME = 4, QUIT = 5 };
    private GameState gameState;
    private GameState currentGameState;

    public int GetLastScene()
    {
        return last_scene;
    }
    public int GetLastOption()
    {
        return last_option;
    }
    public int GetLastLine()
    {
        return last_line;
    }

    public override void Awake()
    {
        base.Awake();
        gameState = GameState.NONE;
        currentGameState = gameState;
        Startup();
    }

    // STATE METHODS //////////////////////////////////////////////////////////

    private void Startup()
    {
        gameState = GameState.STARTUP;
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        //yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(1.5f);
        gameState = GameState.SPLASH;
        StartCoroutine(TransitionScene(1));
    }

    IEnumerator Cut()
    {
        //yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(TransitionScene(2));
    }

    IEnumerator Game()
    {
        //yield return new WaitForSeconds(1.5f);
        yield return null;
        StartCoroutine(TransitionScene(3));
    }

    IEnumerator Quit()
    {
        //yield return new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(1.5f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    /////////////////////////////////////////////////////////////////////////

    public void QuitGame()
    {
        gameState = GameState.QUIT;
    }

    /////////////////////////////////////////////////////////////////////////

    IEnumerator TransitionScene(int scene)
    {
        //float fadeTime = GetComponent<FadeScene>().BeginFade(-1);
        //yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene(scene);
    }

    private void GameStateChanged()
    {
        switch (gameState)
        {
            case GameState.STARTUP:
                break;
            case GameState.SPLASH:
                break;
            case GameState.CUT:
                StartCoroutine(Cut());
                break;
            case GameState.GAME:
                StartCoroutine(Game());
                break;
            case GameState.QUIT:
                StartCoroutine(Quit());
                break;
        }
    }

    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                gameState = GameState.STARTUP;
                break;
            case 1:
                gameState = GameState.SPLASH;
                break;
            case 2:
                gameState = GameState.CUT;
                break;
            case 3:
                gameState = GameState.GAME;
                break;
            case 4:
                gameState = GameState.QUIT;
                break;
        }
    }

    private void CheckState()
    {
        if (currentGameState != gameState)
        {
            currentGameState = gameState;
            GameStateChanged();
        }
    }

    public void Save()
    {
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        //PlayerData data = new PlayerData();
        //data.Health = hp;
        //data.Experience = xp;
        //data.Level = lvl;
        //data.UserName = user;
        //data.UID = uid;

        //formatter.Serialize(file, data);
        //file.Close();
    }

    public void Load()
    {
        // if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        //PlayerData data = (PlayerData)formatter.Deserialize(file);
        //file.Close();
        //hp = data.Health;
        //xp = data.Experience;
        //lvl = data.Level;
        //user = data.UserName;
        //uid = data.UID;
        // }
    }

    void Update()
    {
        CheckState();
    }
}
