using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeReality
{
    public enum GameState
    {
        Running,
        Stopped
    }

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get; private set; }

        private GameState gameState;
        public GameState GameState { get; private set; }

        private TimeTracker timeTracker;
        public TimeTracker TimeTracker { get; private set; }

        public event Action OnGameStart;
        public event Action OnGameStop;

        private void Awake()
        {
            this.timeTracker = new TimeTracker();
        }

        public void GameStart()
        {
            if (this.gameState == GameState.Running)
                return;

            this.gameState = GameState.Running;
            OnGameStart?.Invoke();
        }

        public void GameStop()
        {
            if (this.gameState == GameState.Stopped)
                return;

            this.gameState = GameState.Stopped;
            OnGameStop?.Invoke();
        }
    }
}