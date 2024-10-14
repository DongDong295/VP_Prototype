using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        GameStart,
        InWave,
        SelectBuff,
        GameOver
    }

    public GameState currentState;
    public event Action OnGameStart;
    public event Action OnInWave;
    public event Action OnSelectBuff;
    public event Action OnGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.GameStart);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.GameStart:
                OnGameStart?.Invoke();
                break;

            case GameState.InWave:
                OnInWave?.Invoke();
                break;

            case GameState.SelectBuff:
                OnSelectBuff?.Invoke();
                break;

            case GameState.GameOver:
                OnGameOver?.Invoke();
                break;
        }
    }

    public void StartWave()
    {
        ChangeState(GameState.InWave);
    }

    public void SelectBuff()
    {
        ChangeState(GameState.SelectBuff);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }
}
